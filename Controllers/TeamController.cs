using Microsoft.AspNetCore.Mvc;
using soccer_api.Services;
using soccer_api.ViewModels;

namespace soccer_api.Controllers
{
    [ApiController]
    [Route("/api/team")]
    public class TeamController : ControllerBase
    {
        private readonly ITeamService _teamService;
        
        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;    
        }
        
        [HttpGet]
        public async Task<IResult> Get()
        {
            var teams = await _teamService.GetAllTeamsAsync();
            return Results.Ok(teams);
        }
                
        [HttpGet("{id}")]
        public async Task<IResult> GetById([FromRoute] int id)
        {
            var team = await _teamService.GetTeamByIdAsync(id);
            if (team == null)
            {
                return Results.NotFound();
            }
            
            return Results.Ok(team);
        }
        
        [HttpPost]
        public async Task<IResult> Post(
            [FromBody] TeamViewModel teamViewModel)
        {
            await _teamService.AddTeamAsync(teamViewModel);
            return Results.Ok($"Team {teamViewModel.Name} added sucessfully");
        }
        
        [HttpPut("{id}")]
        public async Task<IResult> Put(
            [FromRoute] int id,
            [FromBody] TeamViewModel teamViewModel)
        {
            await _teamService.UpdateTeamAsync(id, teamViewModel);
            return Results.Ok(teamViewModel);
        }
        
        [HttpDelete("{id}")]
        public async Task<IResult> Get(
            [FromRoute] int id)
        {
            var team = await _teamService.DeleteTeamAsync(id);
            return Results.Ok(team);
        }
    }
}