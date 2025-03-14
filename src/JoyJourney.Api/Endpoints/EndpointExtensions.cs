namespace JoyJourney.Api.Endpoints;

using JoyJourney.Api.Endpoints.Journal;

public static class EndpointExtensions
{
    public static WebApplication UseJournalEndpoints(this WebApplication app)
    {
        var journalGroup = app.MapGroup("/journal")
            //.RequireAuthorization(policy => policy.RequireRole(
            //    JoyJourneyRoles.UserReadOnlyAccess))
            .WithTags("Journal");

        journalGroup.MapGet("/entries", GetJournalEntriesPaginated.Handle);
        journalGroup.MapPost("/", AddJournalEntry.Handle);
        return app;
    }
}
