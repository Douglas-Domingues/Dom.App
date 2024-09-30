﻿using Dom.Api.Common.Api;
using Dom.Api.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Dom.Api.Endpoints.Identity;

public class GetRolesEp : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    => app
        .MapGet("/roles", HandleAsync)
        .WithSummary("Get all the roles available for the current authorized user.")
        .RequireAuthorization();

    private static Task<IResult> HandleAsync(ClaimsPrincipal user)
    {
        if (user.Identity is null || !user.Identity.IsAuthenticated)
            return Task.FromResult(Results.Unauthorized());

        var identity = (ClaimsIdentity)user.Identity;
        var roles = identity
        .FindAll(identity.RoleClaimType)
        .Select(c => new
        {
            c.Issuer,
            c.OriginalIssuer,
            c.Type,
            c.Value,
            c.ValueType
        })
        .ToList();

        return Task.FromResult<IResult>(TypedResults.Json(roles));
    }
}