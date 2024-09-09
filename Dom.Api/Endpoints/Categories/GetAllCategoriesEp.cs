using Dom.Api.Common.Api;
using Dom.Lib.Handlers;
using Dom.Lib.Models;
using Dom.Lib.Requests.Categories;
using Dom.Lib.Responses;
using Microsoft.AspNetCore.Mvc;


namespace Dom.Api.Endpoints.Categories;

public class GetAllCategoriesEp : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapGet("/", HandleAsync)
        .WithName("Categories: Retrieve All")
        .WithSummary("Retrieve a list with all existing categories.")
        .Produces<PagedResponse<List<Category>?>>()
        .WithOrder(3);
    }

    private static async Task<IResult> HandleAsync(ICategoryHandler handler)
    {
        var request = new GetAllCategoriesReq
        {
            UserId = "doug-dev",
        };

        var result = await handler.GetAllAsync(request);

        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}
