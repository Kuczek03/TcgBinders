using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace TcgBinders.Models;

public class LoginViewModel
{
    [Required(ErrorMessage = "Username or email required")]
    [StringLength(100, MinimumLength = 8)]
    [Display(Name = "Username/Email")]
    public string username_email { get; set; }

    [Required(ErrorMessage = "Password required")]
    [StringLength(100, MinimumLength = 8, ErrorMessage = "Password must have more than 8 characters " +
                                                         "and use at least one special character")]
    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    public string password { get; set; }
}