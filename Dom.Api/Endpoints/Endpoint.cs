using Dom.Api.Common.Api;
using Dom.Api.Endpoints.Categories;
using Dom.Api.Endpoints.Identity;
using Dom.Api.Endpoints.Transactions;
using Dom.Api.Models;

namespace Dom.Api.Endpoints;

public static class Endpoint
{
    public static void MapEndpoints(this WebApplication app)
    {
        var endpoints = app
            .MapGroup(""); //tudo feito no grupo é aplicado para todas as rotas

        endpoints.MapGroup("/")
            .WithTags("Health Check")
            .MapGet("", () => new { message = "OK" });
        
        endpoints.MapGroup("v1/categories")
            .WithTags("Categories")
            .RequireAuthorization()
            .MapEndpoint<CreateCategoryEp>()
            .MapEndpoint<GetCategoryByIdEp>()
            .MapEndpoint<GetAllCategoriesEp>()
            .MapEndpoint<UpdateCategoryEp>()
            .MapEndpoint<DeleteCategoryEp>();

        endpoints.MapGroup("v1/transactions")
            .WithTags("Transactions")
            .RequireAuthorization()
            .MapEndpoint<CreateTransactionEp>()
            .MapEndpoint<GetTransactionByIdEp>()
            .MapEndpoint<GetTransactionsByPeriodEp>()
            .MapEndpoint<UpdateTransactionEp>()
            .MapEndpoint<DeleteTransactionEp>();

        endpoints.MapGroup("v1/identity")
            .WithTags("Identity")
            .MapIdentityApi<AppUser>();

        endpoints.MapGroup("v1/identity")
            .WithTags("Identity")
            .MapEndpoint<LogoutEp>()
            .MapEndpoint<GetRolesEp>();

    }

    private static IEndpointRouteBuilder MapEndpoint<TEndpoint>(this IEndpointRouteBuilder app)
        where TEndpoint : IEndpoint
    {
        TEndpoint.Map(app);
        return app;
    }
}
