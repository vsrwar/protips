using ProTips.Business.Dtos;
using ProTips.Entity.Models;

namespace ProTips.Business.Services.Interfaces;

public interface ICountryService
{
    Task<Country> CreateAsync(CountryDto model);
    Task<List<Country>> GetAsync();
    Task<Country> GetAsync(int id);
    Task<Country> UpdateAsync(Country model);
    Task<bool> DeleteAsync(int id);
}