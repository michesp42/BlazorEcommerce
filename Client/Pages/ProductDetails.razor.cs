namespace BlazorEcommerce.Client.Pages;

public partial class ProductDetails
{
    [Inject]
    IProductService ProductService { get; set; }

    [Parameter]
    public int Id { get; set; }

    private Product? _product = null;
    private string _message = string.Empty;

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
        }
    }
}
