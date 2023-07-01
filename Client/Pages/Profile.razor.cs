using Shared.Models;

namespace BlazorEcommerce.Client.Pages;

public partial class Profile
{
    [Inject]
    IAuthenticationService AuthenticationService { get; set; }

    UserChangePassword request = new UserChangePassword();
    string message = string.Empty;

    private async Task ChangePassword()
    {
        var result = await AuthenticationService.ChangePassword(request);
        message = result.Message;
    }
}
