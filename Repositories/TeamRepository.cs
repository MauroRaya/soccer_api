using Microsoft.EntityFrameworkCore;
using Npgsql;
using soccer_api.DTOs;
using soccer_api.Models;

namespace soccer_api.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        private readonly AppDbContext _context;

        public TeamRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Team>> GetAllTeamsAsync()
        {
            return await _context.Teams.ToListAsync();
        }

        public async Task<Team> GetTeamByIdAsync(int id)
        {
            var team = await _context.Teams.FindAsync(id);

            if (team is null)
            {
                throw new Exception("Team not found");
            }
            
            return team;
        }

        public async Task AddTeamAsync(Team team)
        {
            await _context.Teams.AddAsync(team);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTeamAsync(int id, Team newTeam)
        {
            var team = await _context.Teams.FindAsync(id);

            if (team is null)
            {
                throw new Exception("Team not found");
            }
            
            team.Name = newTeam.Name;
            team.FoundedYear = newTeam.FoundedYear;
            team.Income = newTeam.Income;
            team.City = newTeam.City;
            
            await _context.SaveChangesAsync();
        }

        public async Task<TeamDTO> DeleteTeamAsync(int id)
        {
            var team = await _context.Teams.FindAsync(id);

            if (team is null)
            {
                throw new Exception("Team not found");
            }

            var teamDTO = new TeamDTO()
            {
                Id = team.Id,
                Name = team.Name,
                FoundedYear = team.FoundedYear,
                City = team.City,
            };
            
            _context.Teams.Remove(team);
            
            return teamDTO;
        }
    }
}