using Microsoft.AspNetCore.Mvc;
using soccer_api.Models;
using soccer_api.Repositories;
using Npgsql;
using soccer_api.DTOs;
using soccer_api.Services;

namespace soccer_api.Controllers
{
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService _playerService;

        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpGet("/api/player")]
        public async Task<IResult> Get()
        {
            var playersDTO = await _playerService.GetAllPlayersAsync();
            return Results.Ok(playersDTO);
        }

        [HttpGet("/api/player/{id}")]
        public async Task<IResult> GetById(int id)
        {
            var playerDTO = await _playerService.GetPlayerByIdAsync(id);
            return Results.Ok(playerDTO);
        }

        [HttpPost("/api/player")]
        public async Task<IResult> Post(Player player)
        {
            await _playerService.AddPlayerAsync(player);
            return Results.Ok($"Player {player.Name} was added successfully.");
        }
    }
}