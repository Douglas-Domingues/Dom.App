using System.Runtime.CompilerServices;
using Dom.Api.Common.Api;
using Dom.Api.Endpoints.Categories;

namespace Dom.Api.Endpoints;

public static class Endpoint
{
    public static void MapEndpoints(this WebApplication app)
    {
        var endpoints = app
            .MapGroup(""); //tudo feito no grupo é aplicado para todas as rotas

        endpoints.MapGroup("v1/categories")
            .WithTags("Categories")
            .MapEndpoint<CreateCategoryEp>()
            .MapEndpoint<GetCategoryByIdEp>()
            .MapEndpoint<GetAllCategoriesEp>()
            .MapEndpoint<UpdateCategoryEp>()
            .MapEndpoint<DeleteCategoryEp>();
    }

    private static IEndpointRouteBuilder MapEndpoint<TEndpoint>(this IEndpointRouteBuilder app)
        where TEndpoint : IEndpoint
    {
        TEndpoint.Map(app);
        return app;
    }
}
