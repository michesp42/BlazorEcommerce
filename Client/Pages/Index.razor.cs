namespace BlazorEcommerce.Client.Pages;

public partial class Index
{
    [Inject] IProductService ProductService { get; set; }

    [Parameter]
    public string? CategoryUrl { get; set; } = null;
    
    protected override async Task OnParametersSetAsync()
    {
        await ProductService.GetProducts(CategoryUrl);
    }
}