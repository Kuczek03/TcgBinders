using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;

namespace TcgBinders.Models;

[Index(nameof(name), IsUnique = true)]
[Index(nameof(tag), IsUnique = true)]

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