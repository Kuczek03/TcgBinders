using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TcgBinders.Models;

namespace TcgBinders.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Card> Cards { get; set; }

    public DbSet<Set> Sets { get; set; }

    public DbSet<TcgGames> TcgGames { get; set; }

    public DbSet<User> Users { get; set; }
}