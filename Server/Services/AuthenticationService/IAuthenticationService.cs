namespace BlazorEcommerce.Server.Services.AuthenticationService;

public interface IAuthenticationService
{
    Task<ServiceResponse<int>> Register(User user, string password);
    Task<bool> UserExists(string email);
}