using Blazored.LocalStorage;

namespace BlazorEcommerce.Client.Shared;

public partial class CartCounter : IDisposable
{
    [Inject]
    ICartService CartService { get; set; }

    [Inject]
    ISyncLocalStorageService SyncLocalStorageService { get; set; }

    protected override void OnInitialized()
    {
        CartService.OnChange += StateHasChanged;
    }

    public void Dispose()
    {
        CartService.OnChange -= StateHasChanged;
    }

    private int GetCartItemsCount()
    {
        var cart = SyncLocalStorageService.GetItem<List<CartItem>>("cart");
        return cart is not null ? cart.Count : 0;
    }
}
