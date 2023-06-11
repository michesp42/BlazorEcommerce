namespace BlazorEcommerce.Client.Services.AuthenticationService;

public interface IAuthenticationService
{
    Task<ServiceResponse<int>> Register(UserRegister request);
}