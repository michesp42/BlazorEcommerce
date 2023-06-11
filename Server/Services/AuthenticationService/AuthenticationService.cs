namespace BlazorEcommerce.Server.Services.AuthenticationService;

public class AuthenticationService : IAuthenticationService
{
    private readonly DataContext _context;

    public AuthenticationService(DataContext context)
    {
        _context = context;
    }

    public Task<ServiceResponse<int>> Register(User user, string password)
    {
        throw new NotImplementedException();
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
}
