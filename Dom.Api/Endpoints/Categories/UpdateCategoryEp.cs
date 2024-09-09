using Dom.Api.Common.Api;
using Dom.Lib.Handlers;
using Dom.Lib.Models;
using Dom.Lib.Requests.Categories;
using Dom.Lib.Responses;

namespace Dom.Api.Endpoints.Categories;

public class UpdateCategoryEp : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app) =>
        app.MapPut("/{id}", HandleAsync)
        .WithName("Categories: Update")
        .WithSummary("Update an existing category.")
        .Produces<Response<Category?>>()
        .WithOrder(4);

    private static async Task<IResult> HandleAsync(ICategoryHandler handler, UpdateCategoryReq request, long id)
    {
        request.UserId = "doug-dev";
        request.Id = id;

        var result = await handler.UpdateAsync(request);

        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}
