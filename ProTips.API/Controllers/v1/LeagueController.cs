using Microsoft.AspNetCore.Mvc;
using ProTips.Business.Dtos;
using ProTips.Business.Services.Interfaces;
using ProTips.Entity.Models;

namespace ProTips.API.Controllers.v1;

[ApiController]
[ApiVersion("1")]
[Route("api/v{version:apiVersion}/[controller]")]
[Produces("application/json")]
public class LeagueController : ControllerBase
{
    private readonly ILeagueService _leagueService;
    
    public LeagueController(ILeagueService leagueService)
    {
        _leagueService = leagueService;
    }
    
    /// <summary>
    /// Creates a new league
    /// </summary>
    /// <param name="league"></param>
    /// <returns>Brand new created league</returns>
    [HttpPost]
    public async Task<ActionResult<League>> Post([FromBody] LeagueDto league)
    {
        var newLeague = await _leagueService.CreateAsync(league);
        return Ok(newLeague);
    }
    
    /// <summary>
    /// A list of all leagues in the database
    /// </summary>
    /// <returns>All leagues in the database</returns>
    [HttpGet]
    public async Task<ActionResult<List<League>>> Get()
    {
        var leagues = await _leagueService.GetAsync();
        return leagues == null 
            ? NotFound()
            : Ok(leagues);
    }
    
    /// <summary>
    /// Return a single league
    /// </summary>
    /// <returns>A league from database that matches id</returns>
    /// <param name="id">The id of the league to return</param>
    [HttpGet("{id:int}")]
    public async Task<ActionResult<List<League>>> Get([FromRoute] int id)
    {
        var league = await _leagueService.GetAsync(id);
        return league == null
        ? NotFound(id)
        : Ok(league);
    }
    
    /// <summary>
    /// Updates a league
    /// </summary>
    /// <param name="league"></param>
    /// <returns>Updated league</returns>
    [HttpPut]
    public async Task<ActionResult<League>> Put([FromBody] League league)
    {
        var updatedLeague = await _leagueService.UpdateAsync(league);
        return Ok(updatedLeague);
    }
    
    /// <summary>
    /// Deletes a league
    /// </summary>
    /// <param name="id">The id of the league to delete</param>
    /// <returns>Boolean indicating if delete proccess succeed</returns>
    [HttpDelete("{id:int}")]
    public async Task<ActionResult<bool>> Delete([FromRoute] int id)
    {
        var deleted = await _leagueService.DeleteAsync(id);
        return Ok(deleted);
    }
}
