using Npgsql;
using soccer_api.Models;

namespace soccer_api.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        private readonly string _connString;

        public TeamRepository(IConfiguration configuration)
        {
            _connString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<Team>> GetAllAsync()
        {
            using var conn = new NpgsqlConnection(_connString);
            await conn.OpenAsync();

            using var cmd = new NpgsqlCommand("SELECT * FROM team", conn);


            using var reader = await cmd.ExecuteReaderAsync();

            var teams = new List<Team>();
            while (await reader.ReadAsync())
            {
                teams.Add(new Team()
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    FoundedYear = reader.GetInt32(2),
                    City = reader.GetString(3),
                });
            }

            return teams;
        }

        public async Task<Team?> GetByIdAsync(int id)
        {
            using var conn = new NpgsqlConnection(_connString);
            await conn.OpenAsync();

            using var cmd = new NpgsqlCommand("SELECT * FROM team WHERE id = @id", conn);
            cmd.Parameters.AddWithValue("@id", id);

            using var reader = await cmd.ExecuteReaderAsync();

            if (await reader.ReadAsync())
            {
                return new Team()
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    FoundedYear = reader.GetInt32(2),
                    City = reader.GetString(3),
                };
            }

            return null;
        }

        public async Task<int> AddAsync(Team team)
        {
            using var conn = new NpgsqlConnection(_connString);
            await conn.OpenAsync();

            using var cmd =
                new NpgsqlCommand("INSERT INTO team (name, founded_year, city) VALUES (@name, @founded_year, @city)",
                    conn);
            cmd.Parameters.AddWithValue("@name", team.Name);
            cmd.Parameters.AddWithValue("@founded_year", team.FoundedYear);
            cmd.Parameters.AddWithValue("@city", team.City);

            return await cmd.ExecuteNonQueryAsync();
        }
    }
}