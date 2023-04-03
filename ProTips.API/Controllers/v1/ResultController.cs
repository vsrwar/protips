using Microsoft.AspNetCore.Mvc;
using ProTips.Business.Dtos;
using ProTips.Business.Services.Interfaces;
using ProTips.Entity.Models;

namespace ProTips.API.Controllers.v1;

[ApiController]
[ApiVersion("1")]
[Route("api/v{version:apiVersion}/[controller]")]
[Produces("application/json")]
public class ResultController : ControllerBase
{
    private readonly IResultService _resultService;
    
    public ResultController(IResultService resultService)
    {
        _resultService = resultService;
    }
    
    /// <summary>
    /// Creates a new result
    /// </summary>
    /// <param name="result"></param>
    /// <returns>Brand new created result</returns>
    [HttpPost]
    public async Task<ActionResult<Result>> Post([FromBody] ResultDto result)
    {
        var newResult = await _resultService.CreateAsync(result);
        return Ok(newResult);
    }
    
    /// <summary>
    /// A list of all results in the database
    /// </summary>
    /// <returns>All results in the database</returns>
    [HttpGet]
    public async Task<ActionResult<List<Result>>> Get()
    {
        var results = await _resultService.GetAsync();
        return results == null 
            ? NotFound()
            : Ok(results);
    }
    
    /// <summary>
    /// Return a single result
    /// </summary>
    /// <returns>A result from database that matches id</returns>
    /// <param name="id">The id of the result to return</param>
    [HttpGet("{id:int}")]
    public async Task<ActionResult<List<Result>>> Get([FromRoute] int id)
    {
        var result = await _resultService.GetAsync(id);
        return result == null
        ? NotFound(id)
        : Ok(result);
    }
    
    /// <summary>
    /// Updates a result
    /// </summary>
    /// <param name="result"></param>
    /// <returns>Updated result</returns>
    [HttpPut]
    public async Task<ActionResult<Result>> Put([FromBody] Result result)
    {
        var updatedResult = await _resultService.UpdateAsync(result);
        return Ok(updatedResult);
    }
    
    /// <summary>
    /// Deletes a result
    /// </summary>
    /// <param name="id">The id of the result to delete</param>
    /// <returns>Boolean indicating if delete proccess succeed</returns>
    [HttpDelete("{id:int}")]
    public async Task<ActionResult<bool>> Delete([FromRoute] int id)
    {
        var deleted = await _resultService.DeleteAsync(id);
        return Ok(deleted);
    }
}
