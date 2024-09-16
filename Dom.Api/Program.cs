using Dom.Api.Common.Api;
using Dom.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.InitBuilder();

var app = builder.Build();

app.InitiApp();

app.Run();
