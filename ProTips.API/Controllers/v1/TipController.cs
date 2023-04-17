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
public class TipController : ControllerBase
{
    private readonly ITipService _tipService;
    
    public TipController(ITipService tipService)
    {
        _tipService = tipService;
    }
    
    /// <summary>
    /// Creates a new tip
    /// </summary>
    /// <param name="tip"></param>
    /// <returns>Brand new created tip</returns>
    [HttpPost]
    public async Task<ActionResult<Tip>> Post([FromBody] TipDto tip)
    {
        var newTip = await _tipService.CreateAsync(tip);
        return Ok(newTip);
    }
    
    /// <summary>
    /// A list of all tips in the database
    /// </summary>
    /// <returns>All tips in the database</returns>
    [HttpGet]
    public async Task<ActionResult<List<Tip>>> Get()
    {
        var tips = await _tipService.GetAsync();
        return tips == null 
            ? NotFound()
            : Ok(tips);
    }
    
    /// <summary>
    /// Return a single tip
    /// </summary>
    /// <returns>A tip from database that matches id</returns>
    /// <param name="id">The id of the tip to return</param>
    [HttpGet("{id:int}")]
    public async Task<ActionResult<List<Tip>>> Get([FromRoute] int id)
    {
        var tip = await _tipService.GetAsync(id);
        return tip == null
        ? NotFound(id)
        : Ok(tip);
    }
    
    /// <summary>
    /// Updates a tip
    /// </summary>
    /// <param name="tip"></param>
    /// <returns>Updated tip</returns>
    [HttpPut]
    public async Task<ActionResult<Tip>> Put([FromBody] Tip tip)
    {
        var updatedTip = await _tipService.UpdateAsync(tip);
        return Ok(updatedTip);
    }
    
    /// <summary>
    /// Deletes a tip
    /// </summary>
    /// <param name="id">The id of the tip to delete</param>
    /// <returns>Boolean indicating if delete proccess succeed</returns>
    [HttpDelete("{id:int}")]
    public async Task<ActionResult<bool>> Delete([FromRoute] int id)
    {
        var deleted = await _tipService.DeleteAsync(id);
        return Ok(deleted);
    }
}
