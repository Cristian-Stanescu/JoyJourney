﻿using JoyJourney.Data;
using JoyJourney.Data.Entities;
using JoyJourney.ServiceDefaults;
using JoyJourney.WebApp;
using JoyJourney.WebApp.Components;
using JoyJourney.WebApp.Components.Account;
using JoyJourney.WebApp.Endpoints;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire components.
builder.AddServiceDefaults();
builder.AddRedisOutputCache("cache");

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();

builder.Services.AddDbContext<JoyJourneyDbContext>(options =>
{
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("JoyJourney"),
        npgsqlOptions => npgsqlOptions.MigrationsAssembly("JoyJourney.Data.Migrations"));
});

builder.Services.AddIdentity<ApplicationUser, IdentityRole<Guid>>()
        .AddEntityFrameworkStores<JoyJourneyDbContext>()
        .AddSignInManager()
        .AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequiredLength = 8;
});

var apiBaseAddress = builder.Configuration["ApiBaseAddress"] ?? "http://localhost:5293";

builder.Services.AddHttpClient<JournalApiClient>(client => client.BaseAddress = new Uri(apiBaseAddress));
builder.Services.AddMudServices();

builder.Services.AddOpenApi(builder.Configuration);

builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseStaticFiles();

// This cookie policy fixes login issues with Chrome 80+ using HTTP
app.UseCookiePolicy(new CookiePolicyOptions { MinimumSameSitePolicy = SameSiteMode.Lax });
app.UseOpenApi();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseAntiforgery();
app.UseOutputCache();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.MapDefaultEndpoints();

app.UseJoyJournalEndpoints();

// Add additional endpoints required by the Identity /Account Razor components.
app.MapAdditionalIdentityEndpoints();

app.Run();
