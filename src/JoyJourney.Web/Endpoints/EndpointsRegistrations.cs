using JoyJourney.Web.Endpoints.Journal;
using JoyJourney.Web.Endpoints.User;

namespace JoyJourney.Web.Endpoints;
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
