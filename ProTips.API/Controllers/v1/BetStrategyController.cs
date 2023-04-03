using Microsoft.AspNetCore.Mvc;
using ProTips.Business.Dtos;
using ProTips.Business.Services.Interfaces;
using ProTips.Entity.Models;

namespace ProTips.API.Controllers.v1;

[ApiController]
[ApiVersion("1")]
[Route("api/v{version:apiVersion}/[controller]")]
[Produces("application/json")]
public class BetStrategyController : ControllerBase
{
    private readonly IBetStrategyService _betStrategyService;
    
    public BetStrategyController(IBetStrategyService betStrategyService)
    {
        _betStrategyService = betStrategyService;
    }
    
    /// <summary>
    /// Creates a new strategy for bets
    /// </summary>
    /// <param name="betStrategy"></param>
    /// <returns>Brand new created strategy</returns>
    [HttpPost]
    public async Task<ActionResult<BetStrategy>> Post([FromBody] BetStrategy betStrategy)
    {
        var newBetStrategy = await _betStrategyService.CreateAsync(betStrategy);
        return Ok(newBetStrategy);
    }
    
    /// <summary>
    /// A list of all strategies in the database
    /// </summary>
    /// <returns>All strategies in the database</returns>
    [HttpGet]
    public async Task<ActionResult<List<BetStrategy>>> Get()
    {
        var betStrategies = await _betStrategyService.GetAsync();
        return betStrategies == null 
            ? NotFound()
            : Ok(betStrategies);
    }
    
    /// <summary>
    /// Return a single strategy
    /// </summary>
    /// <returns>A strategy from database that matches id</returns>
    /// <param name="id">The id of the strategy to return</param>
    [HttpGet("{id:int}")]
    public async Task<ActionResult<List<BetStrategy>>> Get([FromRoute] int id)
    {
        var betStrategy = await _betStrategyService.GetAsync(id);
        return betStrategy == null
        ? NotFound(id)
        : Ok(betStrategy);
    }
    
    /// <summary>
    /// Updates a strategy
    /// </summary>
    /// <param name="betStrategy"></param>
    /// <returns>Updated strategy</returns>
    [HttpPut]
    public async Task<ActionResult<BetStrategy>> Put([FromBody] BetStrategy betStrategy)
    {
        var updatedBetStrategy = await _betStrategyService.UpdateAsync(betStrategy);
        return Ok(updatedBetStrategy);
    }
    
    /// <summary>
    /// Deletes a strategy
    /// </summary>
    /// <param name="id">The id of the strategy to delete</param>
    /// <returns>Boolean indicating if delete proccess succeed</returns>
    [HttpDelete("{id:int}")]
    public async Task<ActionResult<bool>> Delete([FromRoute] int id)
    {
        var deleted = await _betStrategyService.DeleteAsync(id);
        return Ok(deleted);
    }
}
