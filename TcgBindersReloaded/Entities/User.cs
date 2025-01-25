using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices.JavaScript;
using Microsoft.EntityFrameworkCore;

namespace TcgBindersReloaded.Entities;

[Index(nameof(Username), IsUnique = true)]
[Index(nameof(Email), IsUnique = true)]

public class User
{
    [Key] 
    public int Id { get; set; }

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

    [Required(ErrorMessage = "Email address required")]
    [EmailAddress]
    [Display(Name = "Email")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Creation date required")]
    [DataType(DataType.Date)]
    [Display(Name = "Account creation date")]
    public DateOnly CreationDate { get; set; }
    
    public ICollection<Binder> Binders { get; set; } = new List<Binder>();
    public ICollection<CollectionCards> UserCollectionCards { get; set; } = new List<CollectionCards>();

}