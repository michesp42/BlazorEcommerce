using System.ComponentModel.DataAnnotations;

namespace Shared.Models;

public class UserChangePassword
{
    [Required, StringLength(100, MinimumLength = 6)]
    public string Password { get; set; } = string.Empty;

    [Compare("Password", ErrorMessage = "The passwords do not match")]
    public string PasswordConfirmation { get; set; } = string.Empty;
}
