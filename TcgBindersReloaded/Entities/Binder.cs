using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NuGet.Protocol.Plugins;

namespace TcgBindersReloaded.Entities;

public class Binder
{
    [Key]
    public int Id { get; set; }
    
    [Required, MaxLength(30)]
    public string Name { get; set; }

    public int UserId { get; set; }
    
    [ForeignKey("UserId")]
    public User User { get; set; }

    public ICollection<BinderCards> BCards { get; set; } = new List<BinderCards>();
    
}