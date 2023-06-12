using System.Security.Cryptography;

namespace BlazorEcommerce.Server.Services.AuthenticationService;

public class AuthenticationService : IAuthenticationService
{
    private readonly DataContext _context;

    public AuthenticationService(DataContext context)
    {
        _context = context;
    }

    public async Task<ServiceResponse<string>> Login(string email, string password)
    {
        var response = new ServiceResponse<string>();
        var user = await _context.Users.FirstOrDefaultAsync(
            user => user.Email.ToLower().Equals(email.ToLower())
        );

        if (user == null)
        {
            response.Success = false;
            response.Message = "User not found.";
        }
        else if (!VerfiyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
        {
            response.Success = false;
            response.Message = "Wrong email or password.";
        }
        else
        {
            response.Data = "token";
        }

        return response;
    }

    private bool VerfiyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
    {
        using (var hmac = new HMACSHA256(passwordSalt))
        {
            var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            return computedHash.SequenceEqual(passwordHash);
        }
    }

    public async Task<ServiceResponse<int>> Register(User user, string password)
    {
        if (await UserExists(user.Email))
        {
            return new ServiceResponse<int> { Success = false, Message = "User already exists." };
        }

        CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

        user.PasswordHash = passwordHash;
        user.PasswordSalt = passwordSalt;

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return new ServiceResponse<int> { Data = user.Id, Message = "Registration successful!" };
    }

    public async Task<bool> UserExists(string email)
    {
        if (await _context.Users.AnyAsync(u => u.Email.ToLower().Equals(email.ToLower())))
        {
            return true;
        }

        return false;
    }

    private void CreatePasswordHash(
        string password,
        out byte[] passwordHash,
        out byte[] passwordSalt
    )
    {
        using (var hmac = new HMACSHA512())
        {
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }
    }
}
