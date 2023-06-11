namespace BlazorEcommerce.Server.Services.AuthenticationService;

public class AuthenticationService : IAuthenticationService
{
    public Task<ServiceResponse<int>> Register(User user, string password)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UserExists(string email)
    {
        throw new NotImplementedException();
    }
}