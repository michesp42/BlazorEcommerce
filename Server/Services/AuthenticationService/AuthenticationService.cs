using System.Security.Cryptography;

namespace BlazorEcommerce.Server.Services.AuthenticationService;

public class AuthenticationService : IAuthenticationService
{
    private readonly DataContext _context;

    public AuthenticationService(DataContext context)
    {
        _context = context;
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

        return new ServiceResponse<int> { Data = user.Id };
    }

    public async Task<bool> UserExists(string email)
    {
        if (
            await _context.Users.AnyAsync(
                u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase)
            )
        )
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
