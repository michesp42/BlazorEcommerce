namespace BlazorEcommerce.Client.Pages;

public partial class Register
{
    UserRegister user = new UserRegister();
    
    void HandleRegistration()
    {
        Console.WriteLine($"Register user with email: {user.Email}.");
    }
}