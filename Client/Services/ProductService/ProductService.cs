namespace BlazorEcommerce.Client.Services.ProductService;

public class ProductService : IProductService
{
    private readonly HttpClient _http;

    public ProductService(HttpClient http)
    {
        _http = http;
    }

    public List<Product> Products { get; set; } = new List<Product>();

    public event Action ProductsChanged;

    public async Task<ServiceResponse<Product>> GetProduct(int productId)
    {
        var result = await _http.GetFromJsonAsync<ServiceResponse<Product>>(
            $"api/product/{productId}"
        );

        if (result is not null)
        {
            return result;
        }

        var resultFailed = new ServiceResponse<Product>
        {
            Success = false,
            Message = "Sorry, no product found.",
            Data = null
        };

        return resultFailed;
    }

    public async Task GetProducts(string? categoryUrl = null)
    {
        var result = categoryUrl is null
            ? await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>("api/product")
            : await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>(
                $"api/product/category/{categoryUrl}"
            );

        if (result is not null && result.Data is not null)
        {
            Products = result.Data;
        }

        ProductsChanged.Invoke();
    }
}
