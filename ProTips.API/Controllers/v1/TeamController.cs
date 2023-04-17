using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProTips.Business.Dtos;
using ProTips.Business.Services.Interfaces;
using ProTips.Entity.Models;

namespace ProTips.API.Controllers.v1;

[ApiController]
[ApiVersion("1")]
[Route("api/v{version:apiVersion}/[controller]")]
[Produces("application/json")]
[Authorize]
public class TeamController : ControllerBase
{
    private readonly ITeamService _teamService;
    
    public TeamController(ITeamService teamService)
    {
        _teamService = teamService;
    }
    
    /// <summary>
    /// Creates a new team
    /// </summary>
    /// <param name="team"></param>
    /// <returns>Brand new created team</returns>
    [HttpPost]
    public async Task<ActionResult<Team>> Post([FromBody] TeamDto team)
    {
        var newTeam = await _teamService.CreateAsync(team);
        return Ok(newTeam);
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
    /// Return a single team
    /// </summary>
    /// <returns>A team from database that matches id</returns>
    /// <param name="id">The id of the team to return</param>
    [HttpGet("{id:int}")]
    public async Task<ActionResult<List<Team>>> Get([FromRoute] int id)
    {
        var team = await _teamService.GetAsync(id);
        return Ok(team);
    }
    
    /// <summary>
    /// Updates a team
    /// </summary>
    /// <param name="team"></param>
    /// <returns>Updated team</returns>
    [HttpPut]
    public async Task<ActionResult<Team>> Put([FromBody] Team team)
    {
        var updatedTeam = await _teamService.UpdateAsync(team);
        return Ok(updatedTeam);
    }
    
    /// <summary>
    /// Deletes a team
    /// </summary>
    /// <param name="id">The id of the team to delete</param>
    /// <returns>Boolean indicating if delete proccess succeed</returns>
    [HttpDelete("{id:int}")]
    public async Task<ActionResult<bool>> Delete([FromRoute] int id)
    {
        var deleted = await _teamService.DeleteAsync(id);
        return Ok(deleted);
    }
}