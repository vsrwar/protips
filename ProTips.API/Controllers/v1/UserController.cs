using Microsoft.AspNetCore.Mvc;
using ProTips.Business.Dtos;
using ProTips.Business.Services.Interfaces;
using ProTips.Entity.Models;

namespace ProTips.API.Controllers.v1;

[ApiController]
[ApiVersion("1")]
[Route("api/v{version:apiVersion}/[controller]")]
[Produces("application/json")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    
    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    
    /// <summary>
    /// Creates a new user
    /// </summary>
    /// <param name="user"></param>
    /// <returns>Brand new created user</returns>
    [HttpPost]
    public async Task<ActionResult<User>> Post([FromBody] UserDto user)
    {
        var newUser = await _userService.CreateAsync(user);
        return Ok(newUser);
    }
    
    /// <summary>
    /// A list of all users in the database
    /// </summary>
    /// <returns>All users in the database</returns>
    [HttpGet]
    public async Task<ActionResult<List<User>>> Get()
    {
        var users = await _userService.GetAsync();
        return users == null 
            ? NotFound()
            : Ok(users);
    }
    
    /// <summary>
    /// Return a single user
    /// </summary>
    /// <returns>A user from database that matches id</returns>
    /// <param name="id">The id of the user to return</param>
    [HttpGet("{id:int}")]
    public async Task<ActionResult<List<User>>> Get([FromRoute] int id)
    {
        var user = await _userService.GetAsync(id);
        return user == null
        ? NotFound(id)
        : Ok(user);
    }
    
    /// <summary>
    /// Updates a user
    /// </summary>
    /// <param name="user"></param>
    /// <returns>Updated user</returns>
    [HttpPut]
    public async Task<ActionResult<User>> Put([FromBody] User user)
    {
        var updatedUser = await _userService.UpdateAsync(user);
        return Ok(updatedUser);
    }
    
    /// <summary>
    /// Deletes a user
    /// </summary>
    /// <param name="id">The id of the user to delete</param>
    /// <returns>Boolean indicating if delete proccess succeed</returns>
    [HttpDelete("{id:int}")]
    public async Task<ActionResult<bool>> Delete([FromRoute] int id)
    {
        var deleted = await _userService.DeleteAsync(id);
        return Ok(deleted);
    }
}
