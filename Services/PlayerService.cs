using soccer_api.DTOs;
using soccer_api.Models;
using soccer_api.Repositories;
using soccer_api.ViewModels;

namespace soccer_api.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _repository;

        public PlayerService(IPlayerRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<PlayerDTO>> GetAllPlayersAsync()
        {
            var players = await _repository.GetAllPlayersAsync();

            var playersDTO = new List<PlayerDTO>();

            foreach (var p in players)
            {
                playersDTO.Add(new PlayerDTO()
                {
                    Name = p.Name,
                    AmountGoals = p.AmountGoals,
                    TeamId = p.TeamId,
                });
            }

            return playersDTO;
        }

        public async Task<PlayerDTO?> GetPlayerByIdAsync(int playerId)
        {
            var player = await _repository.GetPlayerByIdAsync(playerId);

            if (player == null)
            {
                return null;
            }

            return new PlayerDTO()
            {
                Id = player.Id,
                Name = player.Name,
                AmountGoals = player.AmountGoals,
                TeamId = player.TeamId,
            };
        }

        public async Task AddPlayerAsync(PlayerViewModel playerViewModel)
        {
            await _repository.AddPlayerAsync(new Player()
            {
                Name = playerViewModel.Name,
                AmountGoals = playerViewModel.AmountGoals,
                Salary = playerViewModel.Salary,
                TeamId = playerViewModel.TeamId
            });
        }
    }
}