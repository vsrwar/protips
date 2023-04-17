using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProTips.Business.Services.Interfaces;

namespace ProTips.API.Controllers.v1;

[ApiController]
[ApiVersion("1")]
[Route("api/v{version:apiVersion}/[controller]")]
[Produces("application/json")]
[Authorize]
public class WalletController : ControllerBase
{
    private readonly IWalletService _walletService;
    
    public WalletController(IWalletService walletService)
    {
        _walletService = walletService;
    }
    
    /// <summary>
    /// Add funds to a user wallet
    /// </summary>
    /// <param name="userId">User Id</param>
    /// <param name="value">Value</param>
    /// <returns>NoContent</returns>
    [HttpPost("{userId:int}/deposit/{value:decimal}")]
    public async Task<ActionResult> Deposit(
        [FromRoute] int userId,
        [FromRoute] decimal value)
    {
        await _walletService.AddFundsAsync(userId, value);
        return NoContent();
    }
    
    /// <summary>
    /// Withdraw funds from a user wallet
    /// </summary>
    /// <param name="userId">User Id</param>
    /// <param name="value">Value</param>
    /// <returns>NoContent</returns>
    [HttpPost("{userId:int}/withdraw/{value:decimal}")]
    public async Task<ActionResult> Withdraw(
        [FromRoute] int userId,
        [FromRoute] decimal value)
    {
        await _walletService.WithdrawFundsAsync(userId, value);
        return NoContent();
    }
}