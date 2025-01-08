using Microsoft.EntityFrameworkCore;
using TcgBinders.Models;

namespace TcgBinders.Data;

public class BindersContext : DbContext
{
    public BindersContext(DbContextOptions<BindersContext> options) : base(options)
    {
        
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cards>().Property(m => m.image).IsRequired(false);  
        modelBuilder.Entity<Cards>().Property(m => m.description).IsRequired(false);  
        
        modelBuilder.Entity<Sets>().Property(m => m.image).IsRequired(false);  
        
        modelBuilder.Entity<Games>().Property(m => m.image).IsRequired(false);  
        modelBuilder.Entity<Games>().Property(m => m.description).IsRequired(false);   
        
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Users> Users { get; set; }
    public DbSet<Games> Games { get; set; }
    public DbSet<Sets> Sets { get; set; }
    public DbSet<Cards> Cards { get; set; }
}
    
    