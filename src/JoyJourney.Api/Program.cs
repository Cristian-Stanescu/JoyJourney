using JoyJourney.Api;
using JoyJourney.Data;
using JoyJourney.Data.Entities;
using JoyJourney.ServiceDefaults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<JoyJourneyDbContext>(options =>
{
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("JoyJourney"),
        npgsqlOptions => npgsqlOptions.MigrationsAssembly("JoyJourney.Data.Migrations"));
});

builder.Services.AddIdentity<ApplicationUser, IdentityRole<Guid>>()
        .AddEntityFrameworkStores<JoyJourneyDbContext>()
        .AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 8;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireLowercase = true;
});

builder.Services.AddOpenApi(builder.Configuration);

var app = builder.Build();

// Apply migrations on startup
//await DatabaseMigrationService.ApplyMigrationsAsync(app.Services);

app.MapDefaultEndpoints();


// This cookie policy fixes login issues with Chrome 80+ using HTTP
app.UseCookiePolicy(new CookiePolicyOptions { MinimumSameSitePolicy = SameSiteMode.Lax });

app.UseOpenApi();
app.UseRouting();
app.UseAuthorization();

app.MapDefaultControllerRoute();

app.Run();
