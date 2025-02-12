using Microsoft.EntityFrameworkCore;
using Npgsql;
using soccer_api.Models;

namespace soccer_api.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly AppDbContext _context;

        public PlayerRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Player>> GetAllPlayersAsync()
        {
            return await _context.Players.ToListAsync();
        }

        public async Task<Player?> GetPlayerByIdAsync(int id)
        {
            return await _context.Players.FindAsync(id);
        }

        public async Task AddPlayerAsync(Player player)
        {
            await _context.Players.AddAsync(player);
            await _context.SaveChangesAsync();
        }
    }
}