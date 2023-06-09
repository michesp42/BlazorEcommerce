namespace BlazorEcommerce.Client.Pages;

public partial class Index
{
    [Inject]
    IProductService ProductService { get; set; }

    [Parameter]
    public string? CategoryUrl { get; set; } = null;

    [Parameter]
    public string? SearchText { get; set; } = null;

    protected override async Task OnParametersSetAsync()
    {
        if (SearchText is not null)
        {
            await ProductService.SearchProducts(SearchText);
        }
        else
        {
            await ProductService.GetProducts(CategoryUrl);
        }
    }
}
