using Dom.Api.Common.Api;

var builder = WebApplication.CreateBuilder(args);

builder.InitBuilder();

var app = builder.Build();

app.InitiApp();

app.Run();
