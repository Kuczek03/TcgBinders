using System.ComponentModel.DataAnnotations;

namespace TcgBindersReloaded.Models;

public class RegisterViewModel
{
    [Required(ErrorMessage = "Username required")]
    [StringLength(100, MinimumLength = 4)]
    [Display(Name = "Username")]
    public string Username { get; set; }

    [Required(ErrorMessage = "Password required")]
    [StringLength(100, MinimumLength = 8, ErrorMessage = "Password must have more than 8 characters " +
                                                         "and use at least one special character")]
    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    public string Password { get; set; }
    
    [Required(ErrorMessage = "Password confirmation required")]
    [StringLength(100, MinimumLength = 8)]
    [DataType(DataType.Password)]
    [Display(Name = "Confirm password")]
    [Compare("Password", ErrorMessage = "Passwords do not match")]
    public string ConfirmPassword { get; set; }

    [Required(ErrorMessage = "Email address required")]
    [EmailAddress]
    [Display(Name = "Email")]
    public string Email { get; set; }
}