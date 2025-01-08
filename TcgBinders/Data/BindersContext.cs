using Microsoft.EntityFrameworkCore;
using TcgBinders.Models;

namespace TcgBinders.Data;

public class BindersContext : DbContext
{
    public BindersContext(DbContextOptions<BindersContext> options) : base(options)
    {
    }

    public DbSet<Users> Users { get; set; }
    public DbSet<Games> Games { get; set; }
    public DbSet<Sets> Sets { get; set; }
    public DbSet<Cards> Cards { get; set; }
}
    
    