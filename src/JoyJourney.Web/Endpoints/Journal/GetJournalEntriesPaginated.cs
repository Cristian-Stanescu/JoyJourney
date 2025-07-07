using JoyJourney.Data;
using JoyJourney.Shared.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace JoyJourney.Web.Endpoints.Journal;

public record GetJournalEntriesPaginatedRequest(int PageNumber = 1, int PageSize = 10);

public record GetJournalEntriesPaginatedResponse(
    int TotalItems,
    IEnumerable<JournalEntryDto> Items
);

public class GetJournalEntriesPaginated
{
    public static async Task<Results<Ok<GetJournalEntriesPaginatedResponse>, NotFound>> Handle(
        [AsParameters] GetJournalEntriesPaginatedRequest request,
        JoyJourneyDbContext dbContext,
        HttpContext httpContext, CancellationToken ct)
    {
        var userId = httpContext.User.FindFirst("sub")?.Value ?? "";
        var user = await dbContext.Users.FirstAsync(u => u.Id == Guid.Parse(userId), ct);

        var totalItems = user.JournalEntries.Count;
        var items = user.JournalEntries
            .OrderByDescending(s => s.CreatedAt)
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .Select(e => JournalEntryDto.FromDomain(e));

        return TypedResults.Ok(new GetJournalEntriesPaginatedResponse(totalItems, items));
    }
}
