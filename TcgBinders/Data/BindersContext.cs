using Microsoft.EntityFrameworkCore;
using TcgBinders.Entities;

namespace TcgBinders.Data;

public class BindersContext : DbContext
{
    public BindersContext(DbContextOptions<BindersContext> options) : base(options)
    {
        
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Card>().Property(m => m.image).IsRequired(false);  
        modelBuilder.Entity<Card>().Property(m => m.description).IsRequired(false);  
        
        modelBuilder.Entity<Sets>().Property(m => m.image).IsRequired(false);  
        
        modelBuilder.Entity<Game>().Property(m => m.image).IsRequired(false);  
        modelBuilder.Entity<Game>().Property(m => m.description).IsRequired(false);   
        
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Game> Games { get; set; }
    public DbSet<Sets> Sets { get; set; }
    public DbSet<Card> Cards { get; set; }
}
    
    