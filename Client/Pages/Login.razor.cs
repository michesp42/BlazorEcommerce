using Blazored.LocalStorage;

namespace BlazorEcommerce.Client.Pages;

public partial class Login
{
    [Inject]
    public IAuthenticationService AuthenticationService { get; set; }
    
    [Inject]
    public ILocalStorageService LocalStorageService { get; set; }
    
    [Inject]
    public NavigationManager NavigationManager { get; set; }

    private UserLogin user = new UserLogin();
    private string errorMessage = string.Empty;

    private async Task HandleLogin()
    {
        var result = await AuthenticationService.Login(user);
        
        if (result.Success)
        {
            errorMessage = string.Empty;
            await LocalStorageService.SetItemAsStringAsync("authenticationToken", result.Data);
            NavigationManager.NavigateTo("/");
        }
        else
        {
            errorMessage = result.Message;
        }
    }
}
