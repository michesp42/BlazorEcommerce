namespace BlazorEcommerce.Client.Pages;

public partial class Cart
{
    [Inject]
    public ICartService CartService { get; set; }
    
    List<CartProductResponse>? cartProducts = null;
    string message = "Loading cart...";
    
    protected override async Task OnInitializedAsync()
    {
        if ((await CartService.GetByCartItems()).Count == 0)
        {
            message = "Your cart is empty.";
            cartProducts = new List<CartProductResponse>();
        }
        else
            {
                cartProducts = await CartService.GetCartProducts();
            }
    }
}
