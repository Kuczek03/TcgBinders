using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TcgBindersReloaded.Entities;

public class BinderCards
{
    [Key]
    public int Id { get; set; }

    
    public int BinderId { get; set; }
    [ForeignKey("BinderId")]
    public Binder Binder { get; set; }
   
    public int CardId { get; set; }
    [ForeignKey("CardId")]
    public Card Card { get; set; }
}