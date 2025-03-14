namespace JoyJourney.Data.Migrations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

public class JoyJourneyContextFactory : IDesignTimeDbContextFactory<JoyJourneyContext>
{
    public JoyJourneyContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .AddJsonFile(Path.Combine(AppContext.BaseDirectory, "appsettings.json"), true)
            .Build();

        var optionsBuilder = new DbContextOptionsBuilder<JoyJourneyContext>()
            .UseNpgsql(configuration.GetConnectionString("JoyJourney"), sql =>
            {
                sql.MigrationsHistoryTable("__efmigrations_joy_journey");
                sql.MigrationsAssembly(typeof(JoyJourneyContextFactory).Assembly.FullName);
            });

        return new JoyJourneyContext(optionsBuilder.Options);
    }
}
