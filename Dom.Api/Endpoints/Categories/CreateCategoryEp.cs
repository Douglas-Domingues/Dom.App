using Dom.Api.Common.Api;
using Dom.Lib.Handlers;
using Dom.Lib.Models;
using Dom.Lib.Requests.Categories;
using Dom.Lib.Responses;
using System.Security.Claims;

namespace Dom.Api.Endpoints.Categories;

public class CreateCategoryEp : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app) =>
        app.MapPost("/", HandleAsync)
        .WithName("Categories: Create")
        .WithSummary("Create a new category.")
        .Produces<Response<Category?>>()
        .WithOrder(1);

    private static async Task<IResult> HandleAsync(ClaimsPrincipal user, ICategoryHandler handler, CreateCategoryReq request)
    {
        request.UserId = user.Identity?.Name ?? string.Empty;
        var result = await handler.CreateAsync(request);

        return result.IsSuccess
            ? TypedResults.Created($"/{result.Data?.Id}", result)
            : TypedResults.BadRequest(result);
    }
}
