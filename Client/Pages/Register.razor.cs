namespace BlazorEcommerce.Client.Pages;

public partial class Register
{
    [Inject]
    public IAuthenticationService AuthenticationService { get; set; }

    string registrationResponseMessage = string.Empty;
    string registrationResponseMessageCssClass = string.Empty;

    UserRegister user = new UserRegister();

    async Task HandleRegistration()
    {
        var result = await AuthenticationService.Register(user);
        registrationResponseMessage = result.Message;

        if (result.Success)
        {
            registrationResponseMessageCssClass = "text-success";
        }
        else
        {
            registrationResponseMessageCssClass = "text-danger";
        }
    }
}
