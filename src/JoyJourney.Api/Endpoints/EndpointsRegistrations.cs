namespace JoyJourney.Api.Endpoints;

using JoyJourney.Api.Endpoints.Journal;
using JoyJourney.Api.Endpoints.User;

public static class EndpointsRegistrations
{
    public static WebApplication UseJoyJournalEndpoints(this WebApplication app)
    {
        var journalGroup = app.MapGroup("/journal")
            //.RequireAuthorization(policy => policy.RequireRole(
            //    JoyJourneyRoles.UserReadOnlyAccess))
            .WithTags("Journal");

        journalGroup.MapGet("/entries", GetJournalEntriesPaginated.Handle);
        journalGroup.MapPost("/", AddJournalEntry.Handle);

        var userGroup = app.MapGroup("/users")
            //.RequireAuthorization(policy => policy.RequireRole(
            //    JoyJourneyRoles.UserReadOnlyAccess))
            .WithTags("User");

        userGroup.MapGet("/", GetUsersPaginated.Handle);

        return app;
    }
}
