using Dom.Api.Common.Api;
using Dom.Lib.Handlers;
using Dom.Lib.Models;
using Dom.Lib.Requests.Categories;
using Dom.Lib.Responses;
using Microsoft.EntityFrameworkCore.Query;

namespace Dom.Api.Endpoints.Categories;

public class GetCategoryByIdEp : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app) =>
        app.MapGet("/{id}", HandleAsync)
        .WithName("Categories: Retrieve")
        .WithSummary("Retrieve an existing category by its ID.")
        .Produces<Response<Category?>>()
        .WithOrder(2);

    private static async Task<IResult> HandleAsync(ICategoryHandler handler, long id)
    {
        var request = new GetCategoryByIdReq
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
