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
public class LinkController : ControllerBase
{
    private readonly ILinkService _linkService;
    
    public LinkController(ILinkService linkService)
    {
        _linkService = linkService;
    }
    
    /// <summary>
    /// Creates a new link
    /// </summary>
    /// <param name="link"></param>
    /// <returns>Brand new created link</returns>
    [HttpPost]
    public async Task<ActionResult<Link>> Post([FromBody] LinkDto link)
    {
        var newLink = await _linkService.CreateAsync(link);
        return Ok(newLink);
    }
    
    /// <summary>
    /// A list of all links in the database
    /// </summary>
    /// <returns>All links in the database</returns>
    [HttpGet]
    public async Task<ActionResult<List<Link>>> Get()
    {
        var links = await _linkService.GetAsync();
        return links == null 
            ? NotFound()
            : Ok(links);
    }
    
    /// <summary>
    /// Return a single link
    /// </summary>
    /// <returns>A link from database that matches id</returns>
    /// <param name="id">The id of the link to return</param>
    [HttpGet("{id:int}")]
    public async Task<ActionResult<List<Link>>> Get([FromRoute] int id)
    {
        var link = await _linkService.GetAsync(id);
        return link == null
        ? NotFound(id)
        : Ok(link);
    }
    
    /// <summary>
    /// Updates a link
    /// </summary>
    /// <param name="link"></param>
    /// <returns>Updated link</returns>
    [HttpPut]
    public async Task<ActionResult<Link>> Put([FromBody] Link link)
    {
        var updatedLink = await _linkService.UpdateAsync(link);
        return Ok(updatedLink);
    }
    
    /// <summary>
    /// Deletes a link
    /// </summary>
    /// <param name="id">The id of the link to delete</param>
    /// <returns>Boolean indicating if delete proccess succeed</returns>
    [HttpDelete("{id:int}")]
    public async Task<ActionResult<bool>> Delete([FromRoute] int id)
    {
        var deleted = await _linkService.DeleteAsync(id);
        return Ok(deleted);
    }
}
