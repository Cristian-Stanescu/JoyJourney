namespace JoyJourney.Api;

using JoyJourney.Data;
using JoyJourney.Data.Entities;
using Microsoft.AspNetCore.Identity;

public class JoyJourneySeed(ILogger<JoyJourneySeed> logger, UserManager<ApplicationUser> userManager) : IDbSeeder<JoyJourneyDbContext>
{
    public async Task SeedAsync(JoyJourneyDbContext context)
    {
        var alice = await userManager.FindByNameAsync("alice");

        if (alice == null)
        {
            alice = new ApplicationUser
            {
                UserName = "alice",
                FirstName = "Alice",
                LastName = "Smith",
                Email = "AliceSmith@email.com",
                EmailConfirmed = true,
                Country = "U.S.",
                Id = Guid.NewGuid(),
                PhoneNumber = "1234567890",
            };

            var result = userManager.CreateAsync(alice, "Pass123$").Result;

            if (!result.Succeeded)
            {
                throw new Exception(result.Errors.First().Description);
            }

            if (logger.IsEnabled(LogLevel.Debug))
            {
                logger.LogDebug("alice created");
            }
        }
        else
        {
            if (logger.IsEnabled(LogLevel.Debug))
            {
                logger.LogDebug("alice already exists");
            }
        }

        var bob = await userManager.FindByNameAsync("bob");

        if (bob == null)
        {
            bob = new ApplicationUser
            {
                UserName = "bob",
                FirstName = "Bob",
                LastName = "Smith",
                Email = "BobSmith@email.com",
                EmailConfirmed = true,
                Country = "U.S.",
                Id = Guid.NewGuid(),
                PhoneNumber = "1234567890",
            };

            var result = await userManager.CreateAsync(bob, "Pass123$");

            if (!result.Succeeded)
            {
                throw new Exception(result.Errors.First().Description);
            }

            if (logger.IsEnabled(LogLevel.Debug))
            {
                logger.LogDebug("bob created");
            }
        }
        else
        {
            if (logger.IsEnabled(LogLevel.Debug))
            {
                logger.LogDebug("bob already exists");
            }
        }
    }
}
