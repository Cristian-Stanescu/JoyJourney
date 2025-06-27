namespace JoyJourney.Data.Migrations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

public class JoyJourneyContextFactory : IDesignTimeDbContextFactory<JoyJourneyDbContext>
{
    public JoyJourneyDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .AddJsonFile(Path.Combine(AppContext.BaseDirectory, "appsettings.Development.json"), true)
            .AddJsonFile(Path.Combine(AppContext.BaseDirectory, "appsettings.json"), true)
            .Build();

        var optionsBuilder = new DbContextOptionsBuilder<JoyJourneyDbContext>()
            .UseNpgsql(configuration.GetConnectionString("joyjourneyDb"), sql =>
            {
                sql.MigrationsHistoryTable("__efmigrations_joy_journey");
                sql.MigrationsAssembly(typeof(JoyJourneyContextFactory).Assembly.FullName);
            });

        return new JoyJourneyDbContext(optionsBuilder.Options);
    }
}
