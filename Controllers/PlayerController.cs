using Microsoft.AspNetCore.Mvc;
using soccer_api.Models;
using soccer_api.Repositories;
using Npgsql;
using soccer_api.DTOs;
using soccer_api.Services;
using soccer_api.ViewModels;

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
            if (playerDTO == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(playerDTO);
        }

        [HttpPost("/api/player")]
        public async Task<IResult> Post(PlayerViewModel playerViewModel)
        {
            await _playerService.AddPlayerAsync(playerViewModel);
            return Results.Ok($"Player {playerViewModel.Name} was added successfully.");
        }
    }
}