using JoyJourney.Data;
using JoyJourney.Data.Entities;
using JoyJourney.ServiceDefaults;
using Microsoft.AspNetCore.Identity;
using JoyJourney.Api;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddControllersWithViews();

builder.AddNpgsqlDbContext<JoyJourneyDbContext>("joy_journey_db");

// Apply database migration automatically. Note that this approach is not
// recommended for production scenarios. Consider generating SQL scripts from
// migrations instead.
builder.Services.AddMigration<JoyJourneyDbContext, JoyJourneySeed>();

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
        .AddEntityFrameworkStores<JoyJourneyDbContext>()
        .AddDefaultTokenProviders();

var app = builder.Build();

app.MapDefaultEndpoints();

app.UseStaticFiles();

// This cookie policy fixes login issues with Chrome 80+ using HTTP
app.UseCookiePolicy(new CookiePolicyOptions { MinimumSameSitePolicy = SameSiteMode.Lax });
app.UseRouting();
app.UseAuthorization();

app.MapDefaultControllerRoute();

app.Run();
