using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TcgBindersReloaded.Entities;

public class UserLogs
{
    [Key]
    public int Id { get; set; }

    public int UserId { get; set; }
    [ForeignKey("UserId")]
    public User User { get; set; }
    public string Message { get; set; }
    public DateTime ActionDate { get; set; }
}