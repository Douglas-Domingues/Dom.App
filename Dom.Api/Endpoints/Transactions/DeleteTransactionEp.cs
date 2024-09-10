﻿using Dom.Api.Common.Api;
using Dom.Lib.Handlers;
using Dom.Lib.Models;
using Dom.Lib.Requests.Transactions;
using Dom.Lib.Responses;

namespace Dom.Api.Endpoints.Transactions;

public class DeleteTransactionEp : IEndpoint
{

    public static void Map(IEndpointRouteBuilder app) =>
        app.MapDelete("/{id}", HandleAsync)
        .WithName("Transactions: Delete")
        .WithSummary("Permanently removes an existing transaction.")
        .Produces<Response<Transaction?>>()
        .WithOrder(5);

    private static async Task<IResult> HandleAsync(ITransactionHandler handler, long id)
    {
        var request = new DeleteTransactionReq
        {
            UserId = "doug-dev",
            Id = id
        };

        var result = await handler.DeleteAsync(request);

        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}