using Dom.Api.Common.Api;
using Dom.Lib.Handlers;
using Dom.Lib.Models;
using Dom.Lib.Requests.Categories;
using Dom.Lib.Responses;
using System.Security.Claims;

namespace Dom.Api.Endpoints.Categories;

public class UpdateCategoryEp : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app) =>
        app.MapPut("/{id}", HandleAsync)
        .WithName("Categories: Update")
        .WithSummary("Update an existing category.")
        .Produces<Response<Category?>>()
        .WithOrder(4);

    private static async Task<IResult> HandleAsync(ClaimsPrincipal user, ICategoryHandler handler, UpdateCategoryReq request, long id)
    {
        request.UserId = user.Identity?.Name ?? string.Empty;
        request.Id = id;

        var result = await handler.UpdateAsync(request);

        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}
