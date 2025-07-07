using JoyJourney.Data;
using JoyJourney.Shared.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace JoyJourney.Web.Endpoints.User;
public record GetUsersPaginatedRequest(int PageNumber = 1, int PageSize = 10);

public record GetUsersPaginatedResponse(
    int TotalItems,
    List<UserDto> Items
);

public class GetUsersPaginated
{
    public static async Task<Results<Ok<GetUsersPaginatedResponse>, NotFound>> Handle(
        [AsParameters] GetUsersPaginatedRequest request,
        JoyJourneyDbContext context, CancellationToken ct)
    {
        var totalItems = await context.Users.CountAsync(ct);
        var items = await context.Users
            .OrderByDescending(s => s.CreatedAt)
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .Select(e => UserDto.FromDomain(e))
            .ToListAsync(ct);

        return TypedResults.Ok(new GetUsersPaginatedResponse(totalItems, items));
    }
}
