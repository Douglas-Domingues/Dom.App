using Dom.Api.Data;
using Dom.Api.Handlers;
using Dom.Api.Models;
using Dom.Lib;
using Dom.Lib.Handlers;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Dom.Api.Common.Api;

public static class BuilderExtensions
{
    public static void AddConfiguration(this WebApplicationBuilder builder)
    {
        Configuration.ConnectionString = builder.Configuration
            .GetConnectionString("DefaultConnection") ?? string.Empty;

        Configuration.BackendUrl = builder.Configuration.GetValue<string>("BackendUrl") ?? string.Empty;
        Configuration.FrontendUrl = builder.Configuration.GetValue<string>("FrontendUrl") ?? string.Empty;
    }

    public static void AddDocs(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer(); // Adiciona o suporte ao OpenAPI
        builder.Services.AddSwaggerGen(x =>
        {
            x.CustomSchemaIds(n => n.FullName); // trata os nomes que serão usadas, pelo fato de repetir requests.
        }); // Adiciona o front-end swagger da API
    }

    public static void AddSecurity(this WebApplicationBuilder builder)
    {
        builder.Services
            .AddAuthentication(IdentityConstants.ApplicationScheme)
            .AddIdentityCookies(); // O identity deve ser iniciado nessa ordem
        
        builder.Services.AddAuthorization(); // O identity deve ser iniciado nessa ordem
    }

    public static void AddDbcontexts(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<AppDbContext>(x =>
            x.UseMySQL(Configuration.ConnectionString)
        );

        builder.Services
            .AddIdentityCore<AppUser>()
            .AddRoles<IdentityRole<long>>()
            .AddEntityFrameworkStores<AppDbContext>()
            .AddApiEndpoints();
    }

    public static void AddServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<ICategoryHandler, CategoryHandler>(); // Injeção de dependência
        builder.Services.AddTransient<ITransactionHandler, TransactionHandler>();
    }
    
    public static void AddCrossOrigin(this WebApplicationBuilder builder)
    {
        builder.Services.AddCors(options => options.AddPolicy(
            ApiConfiguration.CorsPolicyName,
            policy => policy
                .WithOrigins([
                    Configuration.BackendUrl,
                    Configuration.FrontendUrl
                ])
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials())
        );
    }

    public static void InitBuilder(this WebApplicationBuilder builder)
    {
        builder.AddConfiguration();
        builder.AddSecurity();
        builder.AddDbcontexts();
        builder.AddCrossOrigin();
        builder.AddDocs();
        builder.AddServices();
    }


}