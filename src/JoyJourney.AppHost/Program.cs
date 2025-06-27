using Aspire.Hosting;

var builder = DistributedApplication.CreateBuilder(args);
var postgres = builder.AddPostgres("postgres", port: 5432)
    .WithLifetime(ContainerLifetime.Persistent);
var joyjourneyDb = postgres.AddDatabase("joyjourney-db", "joy_journey");

var apiService = builder.AddProject<Projects.JoyJourney_Api>("api-service")
    .WithReference(joyjourneyDb).WaitFor(joyjourneyDb);

var cache = builder.AddRedis("cache");

builder.AddProject<Projects.JoyJourney_Web>("web-frontend")
    .WithExternalHttpEndpoints()
    .WithReference(cache)
    .WithReference(apiService).WaitFor(apiService);

builder.Build().Run();
