using Microsoft.AspNetCore.Mvc;
using ProTips.Business.Dtos;
using ProTips.Business.Services.Interfaces;
using ProTips.Entity.Models;

namespace ProTips.API.Controllers.v1;

[ApiController]
[ApiVersion("1")]
[Route("api/v{version:apiVersion}/[controller]")]
[Produces("application/json")]
public class CountryController : ControllerBase
{
    private readonly IService<Country> _countryService;
    
    public CountryController(IService<Country> countryService)
    {
        _countryService = countryService;
    }
    
    /// <summary>
    /// Creates a new country
    /// </summary>
    /// <param name="country"></param>
    /// <returns>Brand new created country</returns>
    [HttpPost]
    public async Task<ActionResult<Country>> Post([FromBody] CountryDto country)
    {
        var newCountry = await _countryService.CreateAsync(country);
        return Ok(newCountry);
    }
    
    /// <summary>
    /// A list of all countries in the database
    /// </summary>
    /// <returns>All countries in the database</returns>
    [HttpGet]
    public async Task<ActionResult<List<Country>>> Get()
    {
        var countries = await _countryService.GetAsync();
        return countries == null 
            ? NotFound()
            : Ok(countries);
    }
    
    /// <summary>
    /// Return a single country
    /// </summary>
    /// <returns>A country from database that matches id</returns>
    /// <param name="id">The id of the country to return</param>
    [HttpGet("{id:int}")]
    public async Task<ActionResult<List<Country>>> Get([FromRoute] int id)
    {
        var country = await _countryService.GetAsync(id);
        return country == null
        ? NotFound(id)
        : Ok(country);
    }
    
    /// <summary>
    /// Updates a country
    /// </summary>
    /// <param name="country"></param>
    /// <returns>Updated country</returns>
    [HttpPut]
    public async Task<ActionResult<Country>> Put([FromBody] Country country)
    {
        var updatedCountry = await _countryService.UpdateAsync(country);
        return Ok(updatedCountry);
    }
    
    /// <summary>
    /// Deletes a country
    /// </summary>
    /// <param name="id">The id of the country to delete</param>
    /// <returns>Boolean indicating if delete proccess succeed</returns>
    [HttpDelete("{id:int}")]
    public async Task<ActionResult<bool>> Delete([FromRoute] int id)
    {
        var deleted = await _countryService.DeleteAsync(id);
        return Ok(deleted);
    }
}
