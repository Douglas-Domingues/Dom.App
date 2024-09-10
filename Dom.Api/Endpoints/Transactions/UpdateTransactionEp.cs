using Dom.Api.Common.Api;
using Dom.Lib.Handlers;
using Dom.Lib.Models;
using Dom.Lib.Requests.Categories;
using Dom.Lib.Requests.Transactions;
using Dom.Lib.Responses;

namespace Dom.Api.Endpoints.Transactions;

public class UpdateTransactionEp : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app) =>
        app.MapPut("/{id}", HandleAsync)
        .WithName("Transactions: Update")
        .WithSummary("Update an existing transaction.")
        .Produces<Response<Transaction?>>()
        .WithOrder(4);

    private static async Task<IResult> HandleAsync(ITransactionHandler handler, UpdateTransactionReq request, long id)
    {
        request.UserId = "doug-dev";
        request.Id = id;

        var result = await handler.UpdateAsync(request);

        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}
