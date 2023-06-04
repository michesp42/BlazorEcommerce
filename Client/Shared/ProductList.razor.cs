namespace BlazorEcommerce.Client.Shared;

public partial class ProductList : IDisposable
{
    [Inject]
    HttpClient Http { get; set; }

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
