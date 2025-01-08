using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TcgBinders.Models;

public class Sets
{
    [Key]
    [Display(Name ="Set Id")]
    public int id { get; set; }
    
    [StringLength(100)]
    [Display(Name = "Set name")]
    [Required(ErrorMessage = "Set name required")]
    public string name { get; set; }
    
    [StringLength(100)]
    [Display(Name = "Set Description")]
    public string description { get; set; }
    
    [StringLength(10)]
    [Display(Name = "Set tag")]
    [Required(ErrorMessage = "Set tag required")]
    public string tag { get; set; }
    
    [StringLength(10)]
    [Display(Name = "Number of cards in set")]
    [Required(ErrorMessage = "Number of cards required")]
    public int no_of_cards { get; set; }
    
    [StringLength(10)]
    [DataType(DataType.ImageUrl)]
    public string image { get; set; }
    
    [StringLength(10)]
    [Display(Name = "Game tag")]
    [Required(ErrorMessage = "Game tag required")]
    public string game_tag { get; set; }
}