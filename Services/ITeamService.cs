using soccer_api.DTOs;
using soccer_api.Models;
using soccer_api.ViewModels;

namespace soccer_api.Services;

public interface ITeamService
{
    Task<IEnumerable<TeamDTO>> GetAllTeamsAsync();
    Task<TeamDTO> GetTeamByIdAsync(int id);
    Task AddTeamAsync(TeamViewModel team);
    Task UpdateTeamAsync(int id, TeamViewModel team);
    Task<TeamDTO> DeleteTeamAsync(int id);
}