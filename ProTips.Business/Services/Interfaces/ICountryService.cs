using ProTips.Business.Dtos;
using ProTips.Entity.Models;

namespace ProTips.Business.Services.Interfaces;

public interface ICountryService : IService<Country>
{
    Task<Country> CreateAsync(CountryDto model);
}