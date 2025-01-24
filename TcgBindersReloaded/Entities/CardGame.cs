using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace TcgBindersReloaded.Entities;

[Index(nameof(Name), IsUnique = true)]
[Index(nameof(Tag), IsUnique = true)]

public class CardGame
{
    [Key]
    [Display(Name = "Game Id")]
    public int Id { get; set; }
    
    [StringLength(100)]
    [Display(Name = "Game name")]
    [Required(ErrorMessage = "Game name required")]
    public string Name { get; set; }
    
    [StringLength(10)]
    [Display(Name = "Game tag")]
    [Required(ErrorMessage = "Game tag required")]
    public string Tag { get; set; }

    [StringLength(300)]
    [Display(Name = "Game description")]
    public string Description { get; set; }
    
    [StringLength(100)]
    [DataType(DataType.ImageUrl)]
    public string Image { get; set; }   
}