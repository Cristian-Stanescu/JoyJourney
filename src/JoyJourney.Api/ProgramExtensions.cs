using Microsoft.OpenApi.Models;

namespace JoyJourney.Api;
public static class ProgramExtensions
{

    public static void AddJoyJourneySwagger(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "Joy Journey API"
            });

            options.CustomSchemaIds(e => e.FullName!.Replace('+', '.'));

            //var instance = configuration.GetValue<string>("Instance");
            //var tenantId = configuration.GetValue<string>("TenantId");

            //var tokenUrl = $"{instance}{tenantId}/oauth2/v2.0/token";
            //var authorizationUrl = $"{instance}{tenantId}/oauth2/v2.0/authorize";

            //options.AddSecurityDefinition("OAuth2", new OpenApiSecurityScheme
            //{
            //    Name = "OAuth2",
            //    Description = "OAuth2 authentication via AAD",
            //    Type = SecuritySchemeType.OAuth2,
            //    Flows = new OpenApiOAuthFlows
            //    {
            //        AuthorizationCode = new OpenApiOAuthFlow
            //        {
            //            TokenUrl = new Uri(tokenUrl),
            //            RefreshUrl = new Uri(tokenUrl),
            //            AuthorizationUrl = new Uri(authorizationUrl),
            //            Scopes =
            //            {
            //                { $"{configuration.GetValue<string>("Audience")}/.default", "Require assigned roles" }
            //            }
            //        }
            //    }
            //});

            //options.AddSecurityRequirement(new OpenApiSecurityRequirement
            //{
            //    {
            //        new OpenApiSecurityScheme
            //        {
            //            Reference = new OpenApiReference
            //            {
            //                Id = "OAuth2",
            //                Type = ReferenceType.SecurityScheme
            //            }
            //        },
            //        [$"{configuration.GetValue<string>("Audience")}/.default"]
            //    }
            //});
        });
    }

    public static WebApplication UseJoyJourneySwagger(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            //options.OAuthUsePkce();
            //options.OAuthClientId(app.Configuration.GetValue<string>("AzureAd:ClientId"));
            //options.OAuthScopes($"{app.Configuration.GetValue<string>("AzureAd:Audience")}/.default");
            //options.EnablePersistAuthorization();
            options.DefaultModelsExpandDepth(-1);
        });

        return app;
    }
}

