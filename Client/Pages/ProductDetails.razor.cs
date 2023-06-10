namespace BlazorEcommerce.Client.Pages;

public partial class ProductDetails
{
    [Inject]
    IProductService ProductService { get; set; }
    
    [Inject]
    ICartService CartService { get; set; }

    [Parameter]
    public int Id { get; set; }

    private Product? _product = null;
    private string _message = string.Empty;
    private int _currentTypeId = 1;

    protected override async Task OnParametersSetAsync()
    {
        _message = "Loading Product ...";

        var result = await ProductService.GetProduct(Id);

        if (!result.Success)
        {
            _message = result.Message;
        }
        else
        {
            _product = result.Data;

            if (_product is not null && _product.Variants.Count > 0)
            {
                _currentTypeId = _product.Variants[0].ProductTypeId;
            }
        }
    }

    private ProductVariant GetSelectedVariant()
    {
        var variant = new ProductVariant();

        if (_product is not null)
        {
            variant = _product.Variants.FirstOrDefault(v => v.ProductTypeId == _currentTypeId);
        }

        return variant;
    }
    
    private async Task AddToCart()
    {
        var productVariant = GetSelectedVariant();
        var cartItem = new CartItem
        {
            ProductId = productVariant.ProductId,
            ProductTypeId = productVariant.ProductTypeId,
        };
        
        await CartService.AddToCart(cartItem);
    }
}
