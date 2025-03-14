namespace JoyJourney.Api.Endpoints.Journal;

using System.Threading.Tasks;
using JoyJourney.Data;
using JoyJourney.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

public class AddJournalEntry
{
    public static async Task<Ok<Guid>> Handle(
        [FromBody] JournalEntryDto journalEntryDto,
        JoyJourneyContext context, CancellationToken ct)
    {
        var journalEntry = journalEntryDto.MapToDomain();
        await context.JournalEntries.AddAsync(journalEntry, ct);
        context.SaveChanges();

        return TypedResults.Ok(journalEntry.Id);
    }
}
