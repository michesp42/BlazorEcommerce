using Microsoft.AspNetCore.Components.Web;

namespace BlazorEcommerce.Client.Shared;

public partial class Search
{
    [Inject]
    NavigationManager NavigationManager { get; set; }

    [Inject]
    IProductService ProductService { get; set; }

    private string searchText = string.Empty;
    private List<string> suggestions = new List<string>();
    protected ElementReference searchInput;

    public void SearchProducts()
    {
        if (searchText.Equals(string.Empty))
        {
            NavigationManager.NavigateTo("/");
        }
        else
        {
            NavigationManager.NavigateTo($"search/{searchText}");
        }
    }

    public async Task HandleSearch(KeyboardEventArgs args)
    {
        if (args.Key == null || args.Key.Equals("Enter"))
        {
            SearchProducts();
        }
        else if (searchText.Length > 1)
        {
            suggestions = await ProductService.GetProductSearchSuggestions(searchText);
        }
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            await searchInput.FocusAsync();
        }
    }
}
