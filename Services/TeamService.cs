using soccer_api.DTOs;
using soccer_api.Models;
using soccer_api.Repositories;
using soccer_api.ViewModels;

namespace soccer_api.Services;

public class TeamService
{
    private readonly ITeamRepository _repository;

    public TeamService(ITeamRepository repository)
    {
        _repository = repository;
    }

    //trocar para dto
    public async Task<IEnumerable<TeamDTO>> GetAllTeamsAsync()
    {
        var teams = await _repository.GetAllTeamsAsync();

        var teamsDTO = new List<TeamDTO>();

        foreach (var team in teams)
        {
            teamsDTO.Add(new TeamDTO()
            {
                Id = team.Id,
                Name = team.Name,
                FoundedYear = team.FoundedYear,
                City = team.City,
            });
        }

        return teamsDTO;
    }

    public async Task<TeamDTO> GetTeamAsync(int id)
    {
        var team = await _repository.GetTeamByIdAsync(id);

        return new TeamDTO()
        {
            Id = team.Id,
            Name = team.Name,
            FoundedYear = team.FoundedYear,
            City = team.City,
        };
    }

    public async Task AddTeamAsync(TeamViewModel teamViewModel)
    {
        await _repository.AddTeamAsync(new Team()
        {
            Name = teamViewModel.Name,
            FoundedYear = teamViewModel.FoundedYear,
            Income = teamViewModel.Income,
            City = teamViewModel.City,
        });
    }

    public async Task UpdateTeamAsync(int id, TeamViewModel teamViewModel)
    {
        await _repository.UpdateTeamAsync(id, new Team()
        {
            Name = teamViewModel.Name,
            FoundedYear = teamViewModel.FoundedYear,
            Income = teamViewModel.Income,
            City = teamViewModel.City,
        });
    }

    public async Task<TeamDTO> DeleteTeamAsync(int id)
    {
        var team = await _repository.DeleteTeamAsync(id);

        return new TeamDTO()
        {
            Id = team.Id,
            Name = team.Name,
            FoundedYear = team.FoundedYear,
            City = team.City,
        };
    }
}