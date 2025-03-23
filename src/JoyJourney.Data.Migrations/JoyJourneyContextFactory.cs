
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace JoyJourney.Data.Migrations;
public class JoyJourneyContextFactory : IDesignTimeDbContextFactory<JoyJourneyDbContext>
{
    public JoyJourneyDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .AddJsonFile(Path.Combine(AppContext.BaseDirectory, "appsettings.json"), true)
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
