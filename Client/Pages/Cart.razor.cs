namespace BlazorEcommerce.Client.Pages;

public partial class Cart
{
    [Inject]
    public ICartService CartService { get; set; }

    List<CartProductResponse>? cartProducts = null;
    string message = "Loading cart...";

    protected override async Task OnInitializedAsync()
    {
        await LoadCart();
    }

    private async Task RemoveProductFromCart(int productId, int productTypeId)
    {
        await CartService.RemoveFromCart(productId, productTypeId);
        await LoadCart();
    }

    private async Task LoadCart()
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

    private async Task UpdateQuantity(ChangeEventArgs e, CartProductResponse product)
    {
        product.Quantity = int.Parse(e.Value.ToString());

        if (product.Quantity < 1)
        {
            product.Quantity = 1;
        }

        await CartService.UpdateQuantity(product);
    }
}
