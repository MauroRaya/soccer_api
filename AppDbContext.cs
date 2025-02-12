using Microsoft.EntityFrameworkCore;
using soccer_api.Models;

namespace soccer_api;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

    public DbSet<Player> Players { get; set; }
    public DbSet<Team> Teams { get; set; }
    
    //UseSnakeCaseNamingConvetion() method belongs to EFCore.NamingConventions NuGet package
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder
            .UseNpgsql()
            .UseSnakeCaseNamingConvention();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Player>()
            .ToTable("player");
        
        modelBuilder.Entity<Team>()
            .ToTable("team");
    }
}