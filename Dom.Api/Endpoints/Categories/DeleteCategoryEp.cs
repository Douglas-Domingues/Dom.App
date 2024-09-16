using Dom.Api.Common.Api;
using Dom.Lib.Handlers;
using Dom.Lib.Models;
using Dom.Lib.Requests.Categories;
using Dom.Lib.Responses;
using System.Security.Claims;


namespace Dom.Api.Endpoints.Categories;

public class DeleteCategoryEp : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app) =>
        app.MapDelete("/{id}", HandleAsync)
        .WithName("Categories: Delete")
        .WithSummary("Permanently removes an existing category.")
        .Produces<Response<Category?>>()
        .WithOrder(5);

    private static async Task<IResult> HandleAsync(ClaimsPrincipal user, ICategoryHandler handler, long id)
    {
        var request = new DeleteCategoryReq
        {
            UserId = user.Identity?.Name ?? string.Empty,
            Id = id,            
        };

        var result = await handler.DeleteAsync(request);

        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
        
}
