using System.Net.Http.Json;

namespace BlazorEcommerce.Client.Shared;

public partial class ProductList
{
    [Inject]
    HttpClient Http { get; set; }

    private static List<Product> _products = new List<Product>();

    protected override async Task OnInitializedAsync()
    {
        var products = await Http.GetFromJsonAsync<List<Product>>("api/product");
        
        if (products is not null)
        {
            _products = products;
        }
    }
}
