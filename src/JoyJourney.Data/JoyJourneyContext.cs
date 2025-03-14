namespace JoyJourney.Data;

using JoyJourney.Data.Entities;
using Microsoft.EntityFrameworkCore;

public class JoyJourneyContext(DbContextOptions<JoyJourneyContext> options) : DbContext(options)
{
    public DbSet<JournalEntry> JournalEntries { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(JoyJourneyContext).Assembly);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSnakeCaseNamingConvention();
    }
}
