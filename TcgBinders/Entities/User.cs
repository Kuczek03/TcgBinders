using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace TcgBinders.Entities;

[Index(nameof(username), IsUnique = true)]
[Index(nameof(email), IsUnique = true)]

public class User
{
    [Key]
    public int id { get; set; }
    
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
    
    [Required(ErrorMessage = "Email address required")]
    [EmailAddress]
    [Display(Name = "Email")]
    public string email { get; set; }
    
    [Required(ErrorMessage = "Creation date required")]
    [DataType(DataType.Date)]
    [Display(Name = "Account creation date")]
    public DateTime created_at { get; set; } = DateTime.Now;
    
    [DataType(DataType.Date)]
    [Display(Name = "Accounts last update")]
    public DateTime updated_at { get; set; } = DateTime.Now;
    
    [Display(Name = "Status")]
    public int is_active { get; set; }
    
    [Display(Name = "Role")]
    public int user_role { get; set; }
}