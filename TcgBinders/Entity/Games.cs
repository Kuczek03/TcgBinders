using System.ComponentModel.DataAnnotations;

namespace TcgBinders.Models;

public class Games
{
    [Key]
    [Display(Name = "Game Id")]
    public int id { get; set; }
    
    [StringLength(100)]
    [Display(Name = "Game name")]
    [Required(ErrorMessage = "Game name required")]
    public string name { get; set; }
    
    [StringLength(10)]
    [Display(Name = "Game tag")]
    [Required(ErrorMessage = "Game tag required")]
    public string tag { get; set; }
    
    [StringLength(300)]
    [Display(Name = "Game description")]
    public string description { get; set; }
    
    [StringLength(100)]
    [DataType(DataType.ImageUrl)]
    public string image { get; set; }
}