using Microsoft.EntityFrameworkCore;
using Npgsql;
using soccer_api.DTOs;
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

        public async Task UpdatePlayerAsync(int id, Player newPlayer)
        {
            var player = await _context.Players.FindAsync(id);
            
            player.Name = newPlayer.Name;
            player.AmountGoals = newPlayer.AmountGoals;
            player.Salary = newPlayer.Salary;
            player.TeamId = newPlayer.TeamId;
            
            await _context.SaveChangesAsync();
        }

        public async Task<PlayerDTO?> RemovePlayerAsync(int id)
        {
            var player = await _context.Players.FindAsync(id);

            if (player is null)
            {
                return null;
            }
            
            _context.Players.Remove(player);
            
            return new PlayerDTO()
            {
                Id = player.Id,
                Name = player.Name,
                AmountGoals = player.AmountGoals,
                TeamId = player.TeamId,
            };
        }
    }
}