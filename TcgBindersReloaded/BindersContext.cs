using Microsoft.EntityFrameworkCore;
using TcgBindersReloaded.Entities;

namespace TcgBindersReloaded;

public class BindersContext : DbContext
{
    public BindersContext(DbContextOptions<BindersContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
    
    public DbSet<User> Users { get; set; }
}