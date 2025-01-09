using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace TcgBinders.Models;

public class RegisterViewModel
{
    [Required(ErrorMessage = "Username required")]
    [StringLength(100, MinimumLength = 8)]
    [Display(Name = "Username")]
    public string username { get; set; }
    
    [Required(ErrorMessage = "Password required")]
    [StringLength(100, MinimumLength = 8, ErrorMessage = "Password must have more than 8 characters " +
                                                         "and use at least one special character")]
    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    public string password { get; set; }
    
    [Required(ErrorMessage = "Password confirmation required")]
    [StringLength(100, MinimumLength = 8)]
    [DataType(DataType.Password)]
    [Display(Name = "Confirm password")]
    [Compare("password", ErrorMessage = "Passwords do not match")]
    public string confirm_password { get; set; }
    
    [Required(ErrorMessage = "Email address required")]
    [EmailAddress(ErrorMessage = "Invalid email address")]
    [Display(Name = "Email")]
    public string email { get; set; }
}