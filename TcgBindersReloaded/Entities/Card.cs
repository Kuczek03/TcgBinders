using System.ComponentModel.DataAnnotations;

namespace TcgBindersReloaded.Entities;

public class Card
{
    [Key]
    [Display(Name = "Card Id")]
    public int Id { get; set; }
    
    [StringLength(100)]
    [Display(Name = "Card name")]
    [Required(ErrorMessage = "Card name required")]
    public string Name { get; set; }
    
    [StringLength(10)]
    [Display(Name = "Rarity")]
    [Required(ErrorMessage = "Rarity required")]
    public string Rarity { get; set; }
    
    [StringLength(20)]
    [Display(Name = "Type")]
    public string Type { get; set; }

    [StringLength(300)]
    [Display(Name = "Card description")]
    public string Description { get; set; } = String.Empty;
    
    [StringLength(10)]
    [Display(Name = "Number in set")]
    [Required(ErrorMessage = "Card number in set is required")]
    public int NoInSet { get; set; }
    
    [StringLength(10)]
    [Display(Name = "Set tag")]
    [Required(ErrorMessage = "Set tag required")]
    public string SetTag { get; set; }
    
    [StringLength(100)]
    [DataType(DataType.ImageUrl)]
    public string Image { get; set; }
}