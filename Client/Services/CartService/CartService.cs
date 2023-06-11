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
        var cartProducts = await response.Content.ReadFromJsonAsync<
            ServiceResponse<List<CartProductResponse>>
        >();
        return cartProducts.Data;
    }

    public async Task AddToCart(CartItem cartItem)
    {
        var cart = await _localStorageService.GetItemAsync<List<CartItem>>("cart");

        if (cart == null)
        {
            cart = new List<CartItem>();
        }

        var sameItem = cart.Find(
            item =>
                item.ProductId == cartItem.ProductId && item.ProductTypeId == cartItem.ProductTypeId
        );

        if (sameItem == null)
        {
            cart.Add(cartItem);
        }
        else
        {
            sameItem.Quantity += cartItem.Quantity;
        }

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

    public async Task RemoveFromCart(int productId, int productTypeId)
    {
        var cart = await _localStorageService.GetItemAsync<List<CartItem>>("cart");

        if (cart == null)
        {
            return;
        }

        var cartItem = cart.Find(
            item => item.ProductId == productId && item.ProductTypeId == productTypeId
        );

        if (cartItem != null)
        {
            cart.Remove(cartItem);
            await _localStorageService.SetItemAsync<List<CartItem>>("cart", cart);
            OnChange.Invoke();
        }
    }

    public async Task UpdateQuantity(CartProductResponse product)
    {
        var cart = await _localStorageService.GetItemAsync<List<CartItem>>("cart");

        if (cart == null)
        {
            return;
        }

        var cartItem = cart.Find(
            item =>
                item.ProductId == product.ProductId && item.ProductTypeId == product.ProductTypeId
        );

        if (cartItem != null)
        {
            cartItem.Quantity = product.Quantity;
            await _localStorageService.SetItemAsync<List<CartItem>>("cart", cart);
        }
    }
}
