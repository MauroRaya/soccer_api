using Microsoft.EntityFrameworkCore;
using soccer_api;
using soccer_api.Repositories;
using soccer_api.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IPlayerRepository, PlayerRepository>();
builder.Services.AddScoped<IPlayerService, PlayerService>();

string _connString = Environment.GetEnvironmentVariable("DATABASE_CONNECTION", EnvironmentVariableTarget.User);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(_connString));

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.MapGet("/api/ping", () => "pong");

app.Run();
