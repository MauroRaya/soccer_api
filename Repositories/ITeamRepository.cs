using soccer_api.DTOs;
using soccer_api.Models;

namespace soccer_api.Repositories
{
    public interface ITeamRepository
    {
        Task<IEnumerable<Team>> GetAllTeamsAsync();
        Task<Team> GetTeamByIdAsync(int id);
        Task AddTeamAsync(Team team);
        Task UpdateTeamAsync(int id, Team team);
        Task<TeamDTO> DeleteTeamAsync(int id);
    }
}