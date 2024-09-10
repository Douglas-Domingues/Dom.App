using Dom.Api.Common.Api;
using Dom.Lib.Handlers;
using Dom.Lib.Models;
using Dom.Lib.Requests.Transactions;
using Dom.Lib.Responses;

namespace Dom.Api.Endpoints.Transactions;

public class GetTransactionByIdEp : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app) =>
        app.MapGet("/{id}", HandleAsync)
        .WithName("Transactions: Retrieve")
        .WithSummary("Retrieve an existing transaction by its ID.")
        .Produces<Response<Transaction?>>()
        .WithOrder(2);

    private static async Task<IResult> HandleAsync(ITransactionHandler handler, long id)
    {
        var request = new GetTransactionByIdReq
        {
            UserId = "doug-dev",
            Id = id
        };

        var result = await handler.GetByIdAsync(request);

        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}
