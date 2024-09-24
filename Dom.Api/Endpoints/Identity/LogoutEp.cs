using Dom.Api.Common.Api;
using Dom.Api.Models;
using Microsoft.AspNetCore.Identity;

namespace Dom.Api.Endpoints.Identity;

public class LogoutEp : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app
            .MapPost("/logout", HandleAsync)
            .WithSummary("Log out the current authorized user.")
            .RequireAuthorization();

    private static async Task<IResult> HandleAsync(SignInManager<AppUser> signInManager)
    {
        await signInManager.SignOutAsync();
        return Results.Ok();
    }            

}
