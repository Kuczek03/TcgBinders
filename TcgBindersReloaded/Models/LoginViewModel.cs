using System.ComponentModel.DataAnnotations;

namespace TcgBindersReloaded.Models;

public class LoginViewModel
{
    [Required(ErrorMessage = "Username or email required")]
    [StringLength(100, MinimumLength = 4)]
    [Display(Name = "Username/Email")]
    public string UsernameEmail { get; set; }

    [Required(ErrorMessage = "Password required")]
    [StringLength(100, MinimumLength = 8, ErrorMessage = "Password must have more than 8 characters " +
                                                         "and use at least one special character")]
    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    public string Password { get; set; }
}