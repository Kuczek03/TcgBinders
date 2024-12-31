using Microsoft.Build.Framework;

namespace TcgBinders.Models;

public class User
{
    public int id { get; set; }
    public string username { get; set; }
    public string password { get; set; }
    public string email { get; set; }
    public DateTime created_at { get; set; }
    public DateTime updated_at { get; set; }
    public bool is_active { get; set; }
    public bool user_type { get; set; }
}