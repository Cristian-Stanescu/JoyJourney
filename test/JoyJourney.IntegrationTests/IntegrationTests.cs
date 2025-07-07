
using System.Net;
using Aspire.Hosting.ApplicationModel;
using Aspire.Hosting.Testing;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Xunit;

namespace JoyJourney.IntegrationTests;
public class IntegrationTests
{
    [Fact]
    public async Task GetWebResourceRootReturnsOkStatusCode()
    {
        // Arrange
        var appHost = await DistributedApplicationTestingBuilder.CreateAsync<Projects.JoyJourney_AppHost>();
        appHost.Services.ConfigureHttpClientDefaults(clientBuilder =>
        {
            clientBuilder.AddStandardResilienceHandler();
        });
        // To output logs to the xUnit.net ITestOutputHelper, consider adding a package from https://www.nuget.org/packages?q=xunit+logging

        await using var app = await appHost.BuildAsync();
        var resourceNotificationService = app.Services.GetRequiredService<ResourceNotificationService>();
        await app.StartAsync();

        // Act
        var httpClient = app.CreateHttpClient("web-frontend");
        await resourceNotificationService.WaitForResourceAsync("web-frontend", KnownResourceStates.Running).WaitAsync(TimeSpan.FromSeconds(3));
        var response = await httpClient.GetAsync("/");

        // Assert
        response.StatusCode.ShouldBe(HttpStatusCode.OK);

        response = await httpClient.GetAsync("/swagger/v1/swagger.json");

        // Assert
        response.StatusCode.ShouldBe(HttpStatusCode.OK);
    }
}
