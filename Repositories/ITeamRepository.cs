using soccer_api.Models;

namespace soccer_api.Repositories
{
    public interface ITeamRepository
    {
        public Task<IEnumerable<Team>> GetAllAsync();
        public Task<Team?> GetByIdAsync(int id);
        public Task AddAsync(Team team);
    }
}