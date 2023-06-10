namespace BlazorEcommerce.Client.Services.ProductService;

public interface IProductService
{
    event Action ProductsChanged;
    string Message { get; set; }
    List<Product> Products { get; set; }
    int CurrentPage { get; set; }
    int PageCount { get; set; }
    string LastSearchText { get; set; }

    Task GetProducts(string? categoryUrl = null);
    Task<ServiceResponse<Product>> GetProduct(int productId);
    Task SearchProducts(string searchText, int requestedPage);
    Task<List<string>> GetProductSearchSuggestions(string searchText);
}
