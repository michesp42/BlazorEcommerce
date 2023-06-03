namespace BlazorEcommerce.Client.Shared;

public partial class ProductList
{
    [Inject]
    HttpClient Http { get; set; }

    [Inject]
    IProductService ProductService { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await ProductService.GetProducts();
    }
}
