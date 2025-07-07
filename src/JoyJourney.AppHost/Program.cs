var builder = DistributedApplication.CreateBuilder(args);
var postgres = builder.AddPostgres("postgres", port: 5432)
    //.WithHealthCheck("db-health")
    .WithDataVolume("joyjourney-data")
    .WithLifetime(ContainerLifetime.Persistent);
var joyjourneyDb = postgres.AddDatabase("joyjourney-db", "joy_journey");

var cache = builder.AddRedis("cache");

builder.AddProject<Projects.JoyJourney_Web>("web-frontend")
    .WithExternalHttpEndpoints()
    .WithReference(cache)
    .WithReference(joyjourneyDb).WaitFor(joyjourneyDb);

builder.Build().Run();
