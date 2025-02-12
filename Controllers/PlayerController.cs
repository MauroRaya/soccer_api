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
    [Route("/api/player")]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService _playerService;

        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpGet]
        public async Task<IResult> Get()
        {
            var playersDTO = await _playerService.GetAllPlayersAsync();
            return Results.Ok(playersDTO);
        }

        [HttpGet("{id}")]
        public async Task<IResult> GetById(
            [FromRoute] int id)
        {
            var playerDTO = await _playerService.GetPlayerByIdAsync(id);
            if (playerDTO == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(playerDTO);
        }

        [HttpPost]
        public async Task<IResult> Post(
            [FromBody] PlayerViewModel playerViewModel)
        {
            await _playerService.AddPlayerAsync(playerViewModel);
            return Results.Ok($"Player {playerViewModel.Name} was added successfully.");
        }

        [HttpPut("{id}")]
        public async Task<IResult> Put(
            [FromRoute] int id,
            [FromBody] PlayerViewModel playerViewModel)
        {
            await _playerService.UpdatePlayerAsync(id, playerViewModel);
            return Results.Ok(playerViewModel);
        }

        [HttpDelete("{id}")]
        public async Task<IResult> Delete(
            [FromRoute] int id)
        {
            var player = await _playerService.RemovePlayerAsync(id);
            return Results.Ok($"Player {player.Name} was removed successfully.");
        }
    }
}