using soccer_api.Models;

namespace soccer_api.Repositories
{
    public interface IPlayerRepository
    {
        public Task<IEnumerable<Player>> GetAllPlayersAsync();
        public Task<Player?> GetPlayerByIdAsync(int id);
        public Task AddPlayerAsync(Player player);
    }
}