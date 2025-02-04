using soccer_api.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IPlayerRepository, PlayerRepository>();
builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.MapGet("/api/ping", () => "pong");

app.Run();
