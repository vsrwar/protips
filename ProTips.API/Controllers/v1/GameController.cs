using Microsoft.AspNetCore.Mvc;
using ProTips.Business.Dtos;
using ProTips.Business.Services.Interfaces;
using ProTips.Entity.Models;

namespace ProTips.API.Controllers.v1;

[ApiController]
[ApiVersion("1")]
[Route("api/v{version:apiVersion}/[controller]")]
[Produces("application/json")]
public class GameController : ControllerBase
{
    private readonly IService<Game> _gameService;
    
    public GameController(IService<Game> gameService)
    {
        _gameService = gameService;
    }
    
    /// <summary>
    /// Creates a new game
    /// </summary>
    /// <param name="game"></param>
    /// <returns>Brand new created game</returns>
    [HttpPost]
    public async Task<ActionResult<Game>> Post([FromBody] GameDto game)
    {
        var newGame = await _gameService.CreateAsync(game);
        return Ok(newGame);
    }
    
    /// <summary>
    /// A list of all games in the database
    /// </summary>
    /// <returns>All games in the database</returns>
    [HttpGet]
    public async Task<ActionResult<List<Game>>> Get()
    {
        var games = await _gameService.GetAsync();
        return games == null 
            ? NotFound()
            : Ok(games);
    }
    
    /// <summary>
    /// Return a single game
    /// </summary>
    /// <returns>A game from database that matches id</returns>
    /// <param name="id">The id of the game to return</param>
    [HttpGet("{id:int}")]
    public async Task<ActionResult<List<Game>>> Get([FromRoute] int id)
    {
        var game = await _gameService.GetAsync(id);
        return game == null
        ? NotFound(id)
        : Ok(game);
    }
    
    /// <summary>
    /// Updates a game
    /// </summary>
    /// <param name="game"></param>
    /// <returns>Updated game</returns>
    [HttpPut]
    public async Task<ActionResult<Game>> Put([FromBody] Game game)
    {
        var updatedGame = await _gameService.UpdateAsync(game);
        return Ok(updatedGame);
    }
    
    /// <summary>
    /// Deletes a game
    /// </summary>
    /// <param name="id">The id of the game to delete</param>
    /// <returns>Boolean indicating if delete proccess succeed</returns>
    [HttpDelete("{id:int}")]
    public async Task<ActionResult<bool>> Delete([FromRoute] int id)
    {
        var deleted = await _gameService.DeleteAsync(id);
        return Ok(deleted);
    }
}
