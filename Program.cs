using soccer_api.Repositories;
using soccer_api.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IPlayerRepository, PlayerRepository>();
builder.Services.AddScoped<IPlayerService, PlayerService>();
builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.MapGet("/api/ping", () => "pong");

app.Run();
