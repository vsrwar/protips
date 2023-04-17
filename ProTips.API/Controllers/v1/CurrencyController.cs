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
public class CurrencyController : ControllerBase
{
    private readonly ICurrencyService _currencyService;
    
    public CurrencyController(ICurrencyService currencyService)
    {
        _currencyService = currencyService;
    }
    
    /// <summary>
    /// Creates a new currency
    /// </summary>
    /// <param name="currency"></param>
    /// <returns>Brand new created currency</returns>
    [HttpPost]
    public async Task<ActionResult<Currency>> Post([FromBody] CurrencyDto currency)
    {
        var newCurrency = await _currencyService.CreateAsync(currency);
        return Ok(newCurrency);
    }
    
    /// <summary>
    /// A list of all currencies in the database
    /// </summary>
    /// <returns>All currencies in the database</returns>
    [HttpGet]
    public async Task<ActionResult<List<Currency>>> Get()
    {
        var currencies = await _currencyService.GetAsync();
        return currencies == null 
            ? NotFound()
            : Ok(currencies);
    }
    
    /// <summary>
    /// Return a single currency
    /// </summary>
    /// <returns>A currency from database that matches id</returns>
    /// <param name="id">The id of the currency to return</param>
    [HttpGet("{id:int}")]
    public async Task<ActionResult<List<Currency>>> Get([FromRoute] int id)
    {
        var currency = await _currencyService.GetAsync(id);
        return currency == null
        ? NotFound(id)
        : Ok(currency);
    }
    
    /// <summary>
    /// Updates a currency
    /// </summary>
    /// <param name="currency"></param>
    /// <returns>Updated currency</returns>
    [HttpPut]
    public async Task<ActionResult<Currency>> Put([FromBody] Currency currency)
    {
        var updatedCurrency = await _currencyService.UpdateAsync(currency);
        return Ok(updatedCurrency);
    }
    
    /// <summary>
    /// Deletes a currency
    /// </summary>
    /// <param name="id">The id of the currency to delete</param>
    /// <returns>Boolean indicating if delete proccess succeed</returns>
    [HttpDelete("{id:int}")]
    public async Task<ActionResult<bool>> Delete([FromRoute] int id)
    {
        var deleted = await _currencyService.DeleteAsync(id);
        return Ok(deleted);
    }
}
