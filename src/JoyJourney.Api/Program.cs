using System.Text.Json.Serialization;
using JoyJourney.Api;
using JoyJourney.Api.Endpoints;
using JoyJourney.Data;
using JoyJourney.ServiceDefaults;
using JoyJourney.Services;

var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire components.
builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddProblemDetails();
builder.Services.AddJoyJourneyServices(builder.Configuration);
builder.Services.AddJoyJourneyHealthChecks();

//builder.Services.AddAADPostgresDbContext<JoyJourneyContext>(
//    builder.Configuration.GetConnectionString("JoyJourney"));

//builder.Services.AddAuthentication()
//    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));

//builder.Services.AddAuthorization();
builder.Services.AddJoyJourneySwagger(builder.Configuration);
builder.Services.ConfigureHttpJsonOptions(e => e.SerializerOptions.Converters.Add(new JsonStringEnumConverter()));

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseExceptionHandler();

//app.UseAuthentication();
//app.UseAuthorization();

app.UseJoyJourneySwagger();
app.UseJournalEndpoints();

app.Run();
