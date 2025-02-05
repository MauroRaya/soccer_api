using soccer_api.DTOs;
using soccer_api.Models;

namespace soccer_api.Services
{
    public interface IPlayerService
    {
        Task<IEnumerable<PlayerDTO>> GetAllPlayersAsync();
        Task<PlayerDTO?> GetPlayerByIdAsync(int playerId);
        Task AddPlayerAsync(Player player);
    }
}