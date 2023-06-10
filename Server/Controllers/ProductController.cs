namespace BlazorEcommerce.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProducts()
    {
        var products = await _productService.GetProductsAsync();
        return Ok(products);
    }

    [HttpGet("{productId}")]
    public async Task<ActionResult<ServiceResponse<Product>>> GetProduct(int productId)
    {
        var product = await _productService.GetProductAsync(productId);
        return Ok(product);
    }

    [HttpGet("category/{categoryUrl}")]
    public async Task<ActionResult<ServiceResponse<Product>>> GetProductsByCategory(
        string categoryUrl
    )
    {
        var productsOfACategory = await _productService.GetProductByCategory(categoryUrl);
        return Ok(productsOfACategory);
    }

    [HttpGet("search/{searchText}/{requestedPage}")]
    public async Task<ActionResult<ServiceResponse<ProductSearchResult>>> SearchProduct(string searchText, int requestedPage = 1)
    {
        var searchedProducts = await _productService.SearchProducts(searchText, requestedPage);
        return Ok(searchedProducts);
    }

    [HttpGet("search-suggestions/{searchText}")]
    public async Task<ActionResult<ServiceResponse<Product>>> GetProductSearchSuggestions(
        string searchText
    )
    {
        var searchedSuggestions = await _productService.GetProductSearchSuggestions(searchText);
        return Ok(searchedSuggestions);
    }

    [HttpGet("featured")]
    public async Task<ActionResult<ServiceResponse<Product>>> GetFeaturedProducts()
    {
        var searchedSuggestions = await _productService.GetFeaturedProducts();
        return Ok(searchedSuggestions);
    }
}
