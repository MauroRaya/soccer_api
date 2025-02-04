using soccer_api.Models;

namespace soccer_api.Repositories {
    public interface IPlayerRepository {
        public Task<IEnumerable<Player>> GetAllAsync();
        public Task<Player?> GetByIdAsync(int id);
        public Task<int> AddAsync(Player player);
    }
}