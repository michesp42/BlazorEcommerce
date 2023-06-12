using Blazored.LocalStorage;
using Microsoft.AspNetCore.WebUtilities;

namespace BlazorEcommerce.Client.Pages;

public partial class Login
{
    [Inject]
    public IAuthenticationService AuthenticationService { get; set; }

    [Inject]
    public ILocalStorageService LocalStorageService { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Inject]
    public AuthenticationStateProvider AuthenticationStateProvider { get; set; }

    private UserLogin user = new UserLogin();
    private string errorMessage = string.Empty;
    private string returnUrl = string.Empty;

    protected override void OnInitialized()
    {
        var uri = NavigationManager.ToAbsoluteUri(NavigationManager.Uri);

        if (QueryHelpers.ParseQuery(uri.Query).TryGetValue("returnUrl", out var url))
        {
            returnUrl = url;
        }
    }

    private async Task HandleLogin()
    {
        var result = await AuthenticationService.Login(user);

        if (result.Success)
        {
            errorMessage = string.Empty;

            await LocalStorageService.SetItemAsStringAsync("authenticationToken", result.Data);
            await AuthenticationStateProvider.GetAuthenticationStateAsync();

            NavigationManager.NavigateTo(returnUrl);
        }
        else
        {
            errorMessage = result.Message;
        }
    }
}
