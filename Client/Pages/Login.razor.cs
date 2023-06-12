namespace BlazorEcommerce.Client.Pages;

public partial class Login
{
    private UserLogin user = new UserLogin();

    private async Task HandleLogin()
    {
        await Task.Delay(0);
        Console.WriteLine("Log me in!");
    }
}
