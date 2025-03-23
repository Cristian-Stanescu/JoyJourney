
using JoyJourney.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace JoyJourney.Data;
public class JoyJourneyDbContext(DbContextOptions<JoyJourneyDbContext> options) : DbContext(options)
{
    public DbSet<JournalEntry> JournalEntries { get; set; } = null!;
    public DbSet<ApplicationUser> Users { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(JoyJourneyDbContext).Assembly);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSnakeCaseNamingConvention();
    }
}
