namespace BlazorEcommerce.Client.Services.CartService;

public interface ICartService
{
    event Action OnChange;
    
    Task AddToCart(CartItem cartItem);
    Task<List<CartItem>> GetByCartItems();
    Task<List<CartProductResponse>> GetCartProducts();
    Task RemoveFromCart(int productId, int productTypeId);
}
