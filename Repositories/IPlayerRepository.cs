using soccer_api.DTOs;
using soccer_api.Models;

namespace soccer_api.Repositories
{
    public interface IPlayerRepository
    {
        Task<IEnumerable<Player>> GetAllPlayersAsync();
        Task<Player?> GetPlayerByIdAsync(int id);
        Task AddPlayerAsync(Player player);
        Task UpdatePlayerAsync(int id, Player player);
        Task<PlayerDTO?> RemovePlayerAsync(int id);
    }
}