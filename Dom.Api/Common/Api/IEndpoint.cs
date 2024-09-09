using Microsoft.AspNetCore.Routing;

namespace Dom.Api.Common.Api
{
    public interface IEndpoint
    {
        static abstract void Map(IEndpointRouteBuilder app);
    }
}
