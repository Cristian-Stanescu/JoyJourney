namespace JoyJourney.Migrations;

using JoyJourney.Data;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

public class JoyJourneyContextFactory : IDesignTimeDbContextFactory<JoyJourneyDbContext>
{
    public JoyJourneyDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .AddJsonFile(Path.Combine(AppContext.BaseDirectory, "appsettings.Development.json"), true)
            .Build();

        var optionsBuilder = new DbContextOptionsBuilder<JoyJourneyDbContext>()
            .UseNpgsql(configuration.GetConnectionString("JoyJourney"), sql =>
            {
                sql.MigrationsHistoryTable("__efmigrations_joy_journey");
                sql.MigrationsAssembly(typeof(JoyJourneyContextFactory).Assembly.FullName);
            });

        return new JoyJourneyDbContext(optionsBuilder.Options);
    }
}
