using JoyJourney.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace JoyJourney.Api.Endpoints.Journal;

public class AddJournalEntry
{
    public static async Task<Ok<Guid>> Handle(
        [FromBody] JournalEntryDto journalEntryDto,
        JoyJourneyDbContext context, CancellationToken ct)
    {
        var journalEntry = journalEntryDto.MapToDomain();
        await context.JournalEntries.AddAsync(journalEntry, ct);
        context.SaveChanges();

        return TypedResults.Ok(journalEntry.Id);
    }
}
