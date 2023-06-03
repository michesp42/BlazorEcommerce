using System.Net.Http.Json;

namespace BlazorEcommerce.Client.Shared;

public partial class ProductList
{
    [Inject]
    HttpClient Http { get; set; }

    private static List<Product> _products = new List<Product>();

    protected override async Task OnInitializedAsync()
    {
        var response = await Http.GetFromJsonAsync<ServiceResponse<List<Product>>>("api/product");

        if (response is not null && response.Data is not null)
        {
            _products = response.Data;
        }
    }
}
