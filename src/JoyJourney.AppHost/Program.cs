var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache");
var postgres = builder.AddPostgres("postgres")
    .WithLifetime(ContainerLifetime.Persistent);
var joyjourneyDb = postgres.AddDatabase("joyjourney-db", "joy_journey");

var apiService = builder.AddProject<Projects.JoyJourney_Api>("api-service")
    .WithReference(joyjourneyDb);

builder.AddProject<Projects.JoyJourney_Web>("web-frontend")
    .WithExternalHttpEndpoints()
    .WithReference(cache)
    .WithReference(apiService);

builder.Build().Run();
