using Microsoft.AspNetCore.Mvc;
using ProTips.Business.Dtos;
using ProTips.Business.Services.Interfaces;
using ProTips.Entity.Models;

namespace ProTips.API.Controllers.v1;

[ApiController]
[ApiVersion("1")]
[Route("api/v{version:apiVersion}/[controller]")]
[Produces("application/json")]
public class BetController : ControllerBase
{
    private readonly IBetService _betService;
    
    public BetController(IBetService betService)
    {
        _betService = betService;
    }
    
    /// <summary>
    /// Creates a new bet
    /// </summary>
    /// <param name="bet"></param>
    /// <returns>Brand new created bet</returns>
    [HttpPost]
    public async Task<ActionResult<Bet>> Post([FromBody] BetDto bet)
    {
        var newBet = await _betService.CreateAsync(bet);
        return Ok(newBet);
    }
    
    /// <summary>
    /// A list of all bets in the database
    /// </summary>
    /// <returns>All bets in the database</returns>
    [HttpGet]
    public async Task<ActionResult<List<Bet>>> Get()
    {
        var betStrategies = await _betService.GetAsync();
        return betStrategies == null 
            ? NotFound()
            : Ok(betStrategies);
    }
    
    /// <summary>
    /// Return a single bet
    /// </summary>
    /// <returns>A bet from database that matches id</returns>
    /// <param name="id">The id of the bet to return</param>
    [HttpGet("{id:int}")]
    public async Task<ActionResult<List<Bet>>> Get([FromRoute] int id)
    {
        var bet = await _betService.GetAsync(id);
        return bet == null
        ? NotFound(id)
        : Ok(bet);
    }
    
    /// <summary>
    /// Updates a bet
    /// </summary>
    /// <param name="bet"></param>
    /// <returns>Updated </returns>
    [HttpPut]
    public async Task<ActionResult<Bet>> Put([FromBody] Bet bet)
    {
        var updatedBet = await _betService.UpdateAsync(bet);
        return Ok(updatedBet);
    }
    
    /// <summary>
    /// Deletes a bet
    /// </summary>
    /// <param name="id">The id of the  to delete</param>
    /// <returns>Boolean indicating if delete proccess succeed</returns>
    [HttpDelete("{id:int}")]
    public async Task<ActionResult<bool>> Delete([FromRoute] int id)
    {
        var deleted = await _betService.DeleteAsync(id);
        return Ok(deleted);
    }
        
    /// <summary>
    /// Sets if the bet was winner or not
    /// </summary>
    /// <param name="winner">bool winner</param>
    /// <returns>Bet</returns>
    [HttpPost("{id:int}/winner/{winner:bool}")]
    public async Task<ActionResult<Bet>> Winner(
        [FromRoute] int id,
        [FromRoute] bool winner,
        [FromQuery] decimal? value = null)
    {
        var bet = await _betService.WinnerAsync(id, winner, value);
        return Ok(bet);
    }
}
