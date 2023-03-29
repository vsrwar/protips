using Microsoft.AspNetCore.Mvc;
using ProTips.Business.Services.Interfaces;
using ProTips.Entity.Models;

namespace ProTips.API.Controllers.v1;

[ApiController]
[ApiVersion("1")]
[Route("api/v{version:apiVersion}/[controller]")]
[Produces("application/json")]
public class TeamController : ControllerBase
{
    private readonly ITeamService _teamService;
    public TeamController(ITeamService teamService)
    {
        _teamService = teamService;
    }
    
    /// <summary>
    /// A list of all teams in the database
    /// </summary>
    /// <returns>All teams in the database</returns>
    [HttpGet]
    public async Task<ActionResult<List<Team>>> Get()
    {
        var teams = await _teamService.GetAsync();
        return Ok(teams);
    }
    
    /// <summary>
    /// A list a single team
    /// </summary>
    /// <returns>A teams from database that matches id</returns>
    /// <param name="id">The id of the team to return</param>
    [HttpGet("{id:int}")]
    public async Task<ActionResult<List<Team>>> Get(int id)
    {
        var team = await _teamService.GetAsync(id);
        return Ok(team);
    }
}