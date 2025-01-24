using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace TcgBindersReloaded.Entities;

[Index(nameof(Name), IsUnique = true)]
[Index(nameof(Tag), IsUnique = true)]

public class CardSet
{
    [Key]
    [Display(Name ="Set Id")]
    public int Id { get; set; }
    
    [StringLength(100)]
    [Display(Name = "Set name")]
    [Required(ErrorMessage = "Set name required")]
    public string Name { get; set; }

    [StringLength(100)]
    [Display(Name = "Set Description")]
    public string Description { get; set; }
    
    [StringLength(10)]
    [Display(Name = "Set tag")]
    [Required(ErrorMessage = "Set tag required")]
    public string Tag { get; set; }
    
    [Display(Name = "Number of cards in set")]
    [Required(ErrorMessage = "Number of cards required")]
    public int NoOfCards { get; set; }
    
    [StringLength(10)]
    [Display(Name = "Game tag")]
    [Required(ErrorMessage = "Game tag required")]
    public string GameTag { get; set; }
    
    [StringLength(10)]
    [DataType(DataType.ImageUrl)]
    public string image { get; set; }
}