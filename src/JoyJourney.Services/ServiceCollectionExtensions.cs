namespace JoyJourney.Services;

using Azure.Core;
using Azure.Identity;
using JoyJourney.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Client;
using Npgsql;

public static class ServiceCollectionExtensions
{
    private static readonly DefaultAzureCredential _azureCredentials = AppAzureCredential.Instance;
    private static readonly TokenRequestContext _ossrdbmsTokenRequest = new(
    [
        "https://ossrdbms-aad.database.windows.net/.default"
    ]);

    public static IServiceCollection AddJoyJourneyServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddLazyCache();

        //services.AddSingleton<ITimeProvider, TimeProvider>();
        services.Configure<ApplicationOptions>(configuration);

        return services;
    }

    public static IHealthChecksBuilder AddJoyJourneyHealthChecks(this IServiceCollection services)
    {
        return services.AddHealthChecks()
            .AddDbContextCheck<JoyJourneyDbContext>();
    }

    public static IServiceCollection AddAADPostgresDbContext<TContext>(this IServiceCollection services, string? connectionString)
        where TContext : DbContext
    {
        var dataSource = CreateNpgsqlDataSource(connectionString);

        services.AddDbContext<TContext>(options =>
        {
            options.UseNpgsql(dataSource);
            options.ConfigureWarnings(builder =>
            {
                builder.Ignore(CoreEventId.PossibleIncorrectRequiredNavigationWithQueryFilterInteractionWarning);
            });
        });

        return services;
    }

    public static NpgsqlDataSource CreateNpgsqlDataSource(string? connectionString)
    {
        return new NpgsqlDataSourceBuilder(connectionString)
            //.UsePeriodicPasswordProvider(async (builder, ct) =>
            //{
            //    var accessToken = await _azureCredentials.GetTokenAsync(_ossrdbmsTokenRequest, ct);
            //    return accessToken.Token;
            //}, TimeSpan.FromMinutes(55), TimeSpan.FromSeconds(5))
            //.EnableDynamicJson()
            .Build();
    }
}
