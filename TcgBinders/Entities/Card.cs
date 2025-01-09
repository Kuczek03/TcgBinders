using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace TcgBinders.Entities;

public class Card
{
    [Key]
    [Display(Name = "Card Id number")]
    public int id { get; set; }
    
    [StringLength(100)]
    [Display(Name = "Card name")]
    [Required(ErrorMessage = "Card name required")]
    public string name { get; set; }
    
    [StringLength(10)]
    [Display(Name = "Rarity")]
    [Required(ErrorMessage = "Rarity required")]
    public string rarity { get; set; }
    
    [StringLength(20)]
    [Display(Name = "Type")]
    public string type { get; set; }

    [StringLength(300)]
    [Display(Name = "Card description")]
    public string description { get; set; } = String.Empty;
    
    [StringLength(10)]
    [Required(ErrorMessage = "Card number in set is required")]
    public int no_in_set { get; set; }
    
    [StringLength(100)]
    [DataType(DataType.ImageUrl)]
    public string image { get; set; }
}