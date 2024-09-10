using Dom.Api.Data;
using Dom.Api.Handlers;
using Dom.Lib.Handlers;
using Microsoft.EntityFrameworkCore;
using Dom.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);

string cnnStr = builder.Configuration.GetConnectionString("DefaultConnection") ?? string.Empty;

builder.Services.AddEndpointsApiExplorer(); // Adiciona o suporte ao OpenAPI
builder.Services.AddDbContext<AppDbContext>( x =>
    x.UseMySQL(cnnStr)
);
builder.Services.AddSwaggerGen( x =>
{
    x.CustomSchemaIds(n => n.FullName); // trata os nomes que ser�o usadas, pelo fato de repetir requests.
}); // Adiciona o front-end swagger da API
builder.Services.AddTransient<ICategoryHandler, CategoryHandler>(); // Inje��o de depend�ncia
builder.Services.AddTransient<ITransactionHandler, TransactionHandler>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("", () => new { message = "OK" });

Dom.Api.Endpoints.Endpoint.MapEndpoints(app);

app.Run();

/* CICLO DA REQUISI��O
 * Validar o request
 * Verificar se categoria j� existe
 * Inserir categoria no banco
 * Montar a resposta 
 * retornar resposta
 */
