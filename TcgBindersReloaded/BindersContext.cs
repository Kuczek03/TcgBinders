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
        
        modelBuilder.Entity<BinderCards>()
            .HasOne(bc => bc.Binder)
            .WithMany(b => b.BCards)
            .HasForeignKey(bc => bc.BinderId);

        modelBuilder.Entity<BinderCards>()
            .HasOne(bc => bc.Card)
            .WithMany(c => c.Bindes)
            .HasForeignKey(bc => bc.CardId);
        
        modelBuilder.Entity<CollectionCards>()
            .HasOne(cc => cc.User)
            .WithMany(u => u.UserCollectionCards)
            .HasForeignKey(cc => cc.UserId);

        modelBuilder.Entity<CollectionCards>()
            .HasOne(cc => cc.Card)
            .WithMany(c => c.CollectionCardsByUsers)
            .HasForeignKey(cc => cc.CardId);
    }
    
    public DbSet<User> Users { get; set; }
    public DbSet<Card> Cards { get; set; }
    public DbSet<CardSet> CardSets { get; set; }
    public DbSet<CardGame> CardGames { get; set; }
    public DbSet<Binder> Binders { get; set; }
    public DbSet<BinderCards> BinderCards { get; set; }
    public DbSet<CollectionCards> CollectionCards { get; set; }
}