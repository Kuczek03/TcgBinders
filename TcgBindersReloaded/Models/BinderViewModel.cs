using System.ComponentModel.DataAnnotations;

namespace TcgBindersReloaded.Models;

public class BinderViewModel
{
    [Required, MaxLength(30)]
    public string Name { get; set; }
    public int UserId { get; set; }
}