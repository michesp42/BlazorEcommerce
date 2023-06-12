namespace BlazorEcommerce.Client.Services.AuthenticationService;

public interface IAuthenticationService
{
    Task<ServiceResponse<int>> Register(UserRegister request);
    Task<ServiceResponse<string>> Login(UserLogin request); 
}