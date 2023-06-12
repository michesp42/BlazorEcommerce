namespace BlazorEcommerce.Client.Services.AuthenticationService;

public class AuthenticationService : IAuthenticationService
{
    private readonly HttpClient _http;

    public AuthenticationService(HttpClient http)
    {
            _http = http;
    }

    public async Task<ServiceResponse<string>> Login(UserLogin request)
    {
        var result = await _http.PostAsJsonAsync("api/authentication/login", request);
        return await result.Content.ReadFromJsonAsync<ServiceResponse<string>>();
    }

    public async Task<ServiceResponse<int>> Register(UserRegister request)
    {
        var result = await _http.PostAsJsonAsync("api/authentication/register", request);
        return await result.Content.ReadFromJsonAsync<ServiceResponse<int>>();
    }
}