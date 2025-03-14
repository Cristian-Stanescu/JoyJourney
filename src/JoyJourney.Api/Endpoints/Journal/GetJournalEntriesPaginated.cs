namespace JoyJourney.Api.Endpoints.Journal;

using JoyJourney.Data;
using JoyJourney.Shared.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

public record GetJournalEntriesPaginatedRequest(int PageNumber, int PageSize);

public record GetJournalEntriesPaginatedResponse(
    int TotalItems,
    List<JournalEntryDto> Items
);

public class GetJournalEntriesPaginated
{
    public static async Task<Results<Ok<GetJournalEntriesPaginatedResponse>, NotFound>> Handle(
        [AsParameters] GetJournalEntriesPaginatedRequest request,
        JoyJourneyContext context, CancellationToken ct)
    {
        var totalItems = await context.JournalEntries.CountAsync(ct);
        var items = await context.JournalEntries
            .OrderByDescending(s => s.CreatedAt)
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .Select(e => new JournalEntryDto(e.Title, e.CreatedAt))
            .ToListAsync(ct);

        return TypedResults.Ok(new GetJournalEntriesPaginatedResponse(totalItems, []));
    }
}
