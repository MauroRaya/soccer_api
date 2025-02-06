using soccer_api.DTOs;
using soccer_api.ViewModels;

namespace soccer_api.Services
{
    public interface IPlayerService
    {
        Task<IEnumerable<PlayerDTO>> GetAllPlayersAsync();
        Task<PlayerDTO?> GetPlayerByIdAsync(int playerId);
        Task AddPlayerAsync(PlayerViewModel playerViewModel);
    }
}