using Dom.Api.Common.Api;
using Dom.Lib.Handlers;
using Dom.Lib.Models;
using Dom.Lib.Requests.Transactions;
using Dom.Lib.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Dom.Api.Endpoints.Transactions;

public class GetTransactionsByPeriodEp : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapGet("/", HandleAsync)
        .WithName("Transactions: Retrieve All")
        .WithSummary("Retrieve a list with all transactions on certain period.")
        .Produces<PagedResponse<List<Transaction>?>>()
        .WithOrder(3);
    }

    private static async Task<IResult> HandleAsync(
        ClaimsPrincipal user,
        ITransactionHandler handler,
        [FromQuery] int pageNumber,
        [FromQuery] int pageSize,
        [FromQuery] DateTime? startDate = null,
        [FromQuery] DateTime? endDate = null)
    {
        var request = new GetTransactionsByPeriodReq
        {
            PageNumber = pageNumber,
            PageSize = pageSize,
            StartDate = startDate,
            EndDate = endDate,
            UserId = user.Identity?.Name ?? string.Empty,
        };

        var result = await handler.GetByPeriodAsync(request);

        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}
