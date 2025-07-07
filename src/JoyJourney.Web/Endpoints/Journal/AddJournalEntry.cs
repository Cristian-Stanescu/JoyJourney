using JoyJourney.Data;
using JoyJourney.Shared.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JoyJourney.Web.Endpoints.Journal;

public class AddJournalEntry
{
    public static async Task<Ok<Guid>> Handle(
        [FromBody] JournalEntryDto journalEntryDto,
        JoyJourneyDbContext dbContext,
        HttpContext httpContext, CancellationToken ct)
    {
        var journalEntry = journalEntryDto.MapToDomain();

        var userId = httpContext.User.FindFirst("sub")?.Value ?? "";
        var user = await dbContext.Users.FirstAsync(u => u.Id == Guid.Parse(userId), ct);

        user.JournalEntries.Add(journalEntry);
        await dbContext.SaveChangesAsync(ct);

        return TypedResults.Ok(journalEntry.Id);
    }
}
