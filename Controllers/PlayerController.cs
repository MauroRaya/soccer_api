using Microsoft.AspNetCore.Mvc;
using soccer_api.Models;
using soccer_api.Repositories;
using Npgsql;

namespace soccer_api.Controllers {
    [ApiController]
    public class PlayerController : Controller {
        private readonly IPlayerRepository _playerRepository;
        
        public PlayerController(IPlayerRepository playerRepository) {
            _playerRepository = playerRepository;
        }
        
        [HttpGet("/api/player")]
        public async Task<IResult> Get() {
            var players = await _playerRepository.GetAllAsync();
            return Results.Ok(players);
        }

        [HttpGet("/api/player/{id}")]
        public async Task<IResult> GetById(int id) {
            Player? player = await _playerRepository.GetByIdAsync(id);
            return Results.Ok(player);
        }

        [HttpPost("/api/player")]
        public async Task<IResult> Post(Player player) {
            int rowsAffected = await _playerRepository.AddAsync(player);
            
            string message = rowsAffected > 0 ?
                $"Player {player.Name} was successfully added." :
                "Failed to add player";
            
            return Results.Ok(message);
        }
    }
}