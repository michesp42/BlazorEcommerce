using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;

namespace BlazorEcommerce.Server.Services.AuthenticationService;

public class AuthenticationService : IAuthenticationService
{
    private readonly DataContext _context;
    private readonly IConfiguration _configuration;

    public AuthenticationService(DataContext context, IConfiguration configuration)
    {
        _configuration = configuration;
        _context = context;
    }

    public async Task<ServiceResponse<string>> Login(string email, string password)
    {
        var response = new ServiceResponse<string>();
        var user = await _context.Users.FirstOrDefaultAsync(
            u=> u.Email.ToLower().Equals(email.ToLower())
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
            response.Data = CreateToken(user);
        }

        return response;
    }

    private string CreateToken(User user)
    {
        List<Claim> claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Email),
        };

        var key = new SymmetricSecurityKey(
            System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value)
        );
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: credentials
        );
        var jwt = new JwtSecurityTokenHandler().WriteToken(token);

        return jwt;
    }

    private bool VerfiyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
    {
        using (var hmac = new HMACSHA512(passwordSalt))
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
