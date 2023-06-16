using Blazored.LocalStorage;

namespace BlazorEcommerce.Client.Shared;

public partial class UserButton
{
    [Inject]
    public ILocalStorageService LocalStorageService { get; set; }

    [Inject]
    public AuthenticationStateProvider AuthenticationStateProvider { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    private bool showUserMenu = false;
    private string UserMenuCssClass => showUserMenu ? "show-menu" : string.Empty;

    private void ToggleUserMenu()
    {
        showUserMenu = !showUserMenu;
    }

    private async Task HideUserMenu()
    {
        await Task.Delay(200);
        showUserMenu = false;
    }

    private async Task Logout()
    {
        await LocalStorageService.RemoveItemAsync("authenticationToken");
        await AuthenticationStateProvider.GetAuthenticationStateAsync();
        NavigationManager.NavigateTo("/");
    }
}
