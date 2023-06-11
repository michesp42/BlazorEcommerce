using Blazored.LocalStorage;

namespace BlazorEcommerce.Client.Services.CartService;

public class CartService : ICartService
{
    private readonly ILocalStorageService _localStorageService;
    private readonly HttpClient _http;

    public CartService(ILocalStorageService localStorageService, HttpClient http)
    {
        _localStorageService = localStorageService;
        _http = http;
    }

    public event Action OnChange;

    public async Task<List<CartProductResponse>> GetCartProducts()
    {
        var cartItems = await _localStorageService.GetItemAsync<List<CartItem>>("cart");
        var response = await _http.PostAsJsonAsync("api/cart/products", cartItems);
        var cartProducts = await response.Content.ReadFromJsonAsync<ServiceResponse<List<CartProductResponse>>>();
        return cartProducts.Data;
    }

    public async Task AddToCart(CartItem cartItem)
    {
        var cart = await _localStorageService.GetItemAsync<List<CartItem>>("cart");

        if (cart == null)
        {
            cart = new List<CartItem>();
        }

        cart.Add(cartItem);

        await _localStorageService.SetItemAsync("cart", cart);
        OnChange.Invoke();
    }

    public async Task<List<CartItem>> GetByCartItems()
    {
        var cart = await _localStorageService.GetItemAsync<List<CartItem>>("cart");

        if (cart == null)
        {
            cart = new List<CartItem>();
        }

        return cart;
    }
}
