namespace BlazorEcommerce.Client.Pages;

public partial class ProductDetails
{
    [Inject]
    IProductService ProductService { get; set; }

    [Parameter]
    public int Id { get; set; }

    private Product? product = null;

    protected override async Task OnParametersSetAsync()
    {
        product = ProductService.Products.Find(p => p.Id == Id);
    }
}
