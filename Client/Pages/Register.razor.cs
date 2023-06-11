namespace BlazorEcommerce.Client.Pages;

public partial class Register
{
    [Inject]
    public IAuthenticationService AuthenticationService { get; set; }
    
    string errorMessage = string.Empty;

    UserRegister user = new UserRegister();
    
    async Task HandleRegistration()
    {
        var result = await AuthenticationService.Register(user);
        
        if (!result.Success)
        {
            errorMessage = result.Message;
        }
    }
}