namespace BlazorEcommerce.Server.Services.CartService;

public class CartService : ICartService
{
    private readonly DataContext _context;

    public CartService(DataContext context)
    {
        _context = context;
    }

    public async Task<ServiceResponse<List<CartProductResponse>>> GetCartProducts(
        List<CartItem> cartItems
    )
    {
        var result = new ServiceResponse<List<CartProductResponse>>
        {
            Data = new List<CartProductResponse>()
        };

        foreach (var cartItem in cartItems)
        {
            var product = await _context.Products
                .Where(p => p.Id == cartItem.ProductId)
                .FirstOrDefaultAsync();

            if (product == null)
            {
                continue;
            }

            var productVariant = await _context.ProductVariants
                .Where(
                    v =>
                        v.ProductId == cartItem.ProductId
                        && v.ProductTypeId == cartItem.ProductTypeId
                )
                .Include(v => v.ProductType)
                .FirstOrDefaultAsync();

            if (productVariant == null)
            {
                continue;
            }

            var cartProduct = new CartProductResponse
            {
                ProductId = product.Id,
                Title = product.Title,
                ImageUrl = product.ImageUrl,
                Price = productVariant.Price,
                ProductType = productVariant.ProductType.Name,
                ProductTypeId = productVariant.ProductTypeId,
                Quantity = cartItem.Quantity
            };

            result.Data.Add(cartProduct);
        }

        return result;
    }

    public async Task<ServiceResponse<List<CartProductResponse>>> StoreCartItems(
        List<CartItem> cartItems,
        int userId
    )
    {
        cartItems.ForEach(cartItem => cartItem.UserId = userId);
        _context.CarItems.AddRange(cartItems);
        await _context.SaveChangesAsync();

        return await GetCartProducts(
            await _context.CarItems.Where(ci => ci.UserId == userId).ToListAsync()
        );
    }
}
