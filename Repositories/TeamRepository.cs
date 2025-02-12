using Microsoft.EntityFrameworkCore;
using Npgsql;
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

        public async Task<IEnumerable<Team>> GetAllAsync()
        {
            return await _context.Teams.ToListAsync();
        }

        public async Task<Team?> GetByIdAsync(int id)
        {
            return await _context.Teams.FindAsync(id);
        }

        public async Task AddAsync(Team team)
        {
            await _context.Teams.AddAsync(team);
            await _context.SaveChangesAsync();
        }
    }
}