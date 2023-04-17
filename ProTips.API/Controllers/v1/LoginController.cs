using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProTips.Business.Dtos;
using ProTips.Business.Services.Interfaces;

namespace ProTips.API.Controllers.v1;

[ApiController]
[ApiVersion("1")]
[Route("api/v{version:apiVersion}/[controller]")]
[Produces("application/json")]
[AllowAnonymous]
public class LoginController : ControllerBase
{
    private readonly ILoginService _loginService;

    public LoginController(ILoginService loginService)
    {
        _loginService = loginService;
    }
    
    /// <summary>
    /// Logs in a user
    /// </summary>
    /// <param name="login">User login email and password</param>
    /// <returns>User token</returns>
    [HttpPost]
    public async Task<ActionResult<UserAuthenticated>> Post([FromBody] LoginDto login)
    {
        var user = await _loginService.LoginAsync(login);
        return Ok(user);
    }
}