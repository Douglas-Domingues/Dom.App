using Dom.Api.Common.Api;
using Dom.Lib.Handlers;
using Dom.Lib.Models;
using Dom.Lib.Requests.Transactions;
using Dom.Lib.Responses;

namespace Dom.Api.Endpoints.Transactions;

public class CreateTransactionEp : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app) =>
        app.MapPost("/", HandleAsync)
        .WithName("Transactions: Create")
        .WithSummary("Create a new transaction.")
        .Produces<Response<Transaction?>>()
        .WithOrder(1);

    private static async Task<IResult> HandleAsync(ITransactionHandler handler, CreateTransactionReq request)
    {
        request.UserId = "doug-dev";
        var result = await handler.CreateAsync(request);

        return result.IsSuccess
            ? TypedResults.Created($"/{result.Data?.Id}", result)
            : TypedResults.BadRequest(result);
    }
}
