using Microsoft.AspNetCore.Mvc;
using ProTips.Business.Dtos;
using ProTips.Business.Services.Interfaces;
using ProTips.Entity.Models;

namespace ProTips.API.Controllers.v1;

[ApiController]
[ApiVersion("1")]
[Route("api/v{version:apiVersion}/[controller]")]
[Produces("application/json")]
public class PreLiveController : ControllerBase
{
    private readonly IPreLiveService _preLiveService;
    
    public PreLiveController(IPreLiveService preLiveService)
    {
        _preLiveService = preLiveService;
    }
    
    /// <summary>
    /// Creates a new preLive
    /// </summary>
    /// <param name="preLive"></param>
    /// <returns>Brand new created preLive</returns>
    [HttpPost]
    public async Task<ActionResult<PreLive>> Post([FromBody] PreLiveDto preLive)
    {
        var newPreLive = await _preLiveService.CreateAsync(preLive);
        return Ok(newPreLive);
    }
    
    /// <summary>
    /// A list of all preLives in the database
    /// </summary>
    /// <returns>All preLives in the database</returns>
    [HttpGet]
    public async Task<ActionResult<List<PreLive>>> Get()
    {
        var preLives = await _preLiveService.GetAsync();
        return preLives == null 
            ? NotFound()
            : Ok(preLives);
    }
    
    /// <summary>
    /// Return a single preLive
    /// </summary>
    /// <returns>A preLive from database that matches id</returns>
    /// <param name="id">The id of the preLive to return</param>
    [HttpGet("{id:int}")]
    public async Task<ActionResult<List<PreLive>>> Get([FromRoute] int id)
    {
        var preLive = await _preLiveService.GetAsync(id);
        return preLive == null
        ? NotFound(id)
        : Ok(preLive);
    }
    
    /// <summary>
    /// Updates a preLive
    /// </summary>
    /// <param name="preLive"></param>
    /// <returns>Updated preLive</returns>
    [HttpPut]
    public async Task<ActionResult<PreLive>> Put([FromBody] PreLive preLive)
    {
        var updatedPreLive = await _preLiveService.UpdateAsync(preLive);
        return Ok(updatedPreLive);
    }
    
    /// <summary>
    /// Deletes a preLive
    /// </summary>
    /// <param name="id">The id of the preLive to delete</param>
    /// <returns>Boolean indicating if delete proccess succeed</returns>
    [HttpDelete("{id:int}")]
    public async Task<ActionResult<bool>> Delete([FromRoute] int id)
    {
        var deleted = await _preLiveService.DeleteAsync(id);
        return Ok(deleted);
    }
}
