using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TcgBindersReloaded.Entities;

public class CollectionCards
{
    [Key]
    public int Id { get; set; }

    public int UserId { get; set; }
    
    [ForeignKey("UserId")]
    public User User { get; set; }
   
    public int CardId { get; set; }
    [ForeignKey("CardId")]
    public Card Card { get; set; }
}