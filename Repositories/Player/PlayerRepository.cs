using Npgsql;
using soccer_api.Models;

namespace soccer_api.Repositories {
    public class PlayerRepository : IPlayerRepository {
        private readonly string _connString;
        
        public PlayerRepository(IConfiguration configuration) {
            _connString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<Player>> GetAllAsync() {
            using var conn = new NpgsqlConnection(_connString);
            await conn.OpenAsync();

            using var cmd = new NpgsqlCommand("SELECT * FROM player", conn);

            using var reader = await cmd.ExecuteReaderAsync();
            
            var players = new List<Player>();
            while (await reader.ReadAsync()) {
                players.Add(new Player() {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    AmountGoals = reader.GetInt32(2),
                    TeamId = reader.GetInt32(3)
                });
            }
            return players;
        }

        public async Task<Player?> GetByIdAsync(int id) {
            using var conn = new NpgsqlConnection(_connString);
            await conn.OpenAsync();

            using var cmd = new NpgsqlCommand("SELECT * FROM player WHERE id = @id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            
            using var reader = await cmd.ExecuteReaderAsync();
            
            if (await reader.ReadAsync()) {
                return new Player() {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    AmountGoals = reader.GetInt32(2),
                    TeamId = reader.GetInt32(3)
                };
            }
            return null;
        }

        public async Task<int> AddAsync(Player player) {
            using var conn = new NpgsqlConnection(_connString);
            await conn.OpenAsync();

            using var cmd = new NpgsqlCommand("INSERT INTO player (name, amountGoals, teamId) VALUES (@name, @amountGoals, @teamId)", conn);
            cmd.Parameters.AddWithValue("@name",        player.Name);
            cmd.Parameters.AddWithValue("@amountGoals", player.AmountGoals);
            cmd.Parameters.AddWithValue("@teamId",      player.TeamId);

            return await cmd.ExecuteNonQueryAsync();
        }
    }
}