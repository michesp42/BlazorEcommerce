namespace BlazorEcommerce.Client.Shared;

public partial class FeaturedProducts : IDisposable
{
    [Inject]
    IProductService ProductService { get; set; }

    protected override void OnInitialized()
    {
        ProductService.ProductsChanged += StateHasChanged;
    }

    public void Dispose()
    {
        ProductService.ProductsChanged -= StateHasChanged;
    }
}
