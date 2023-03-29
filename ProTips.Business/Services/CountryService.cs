using ProTips.Business.Configuration;
using ProTips.Business.Dtos;
using ProTips.Business.Services.Interfaces;
using ProTips.Entity.Models;
using ProTips.Entity.Repository;

namespace ProTips.Business.Services;

public class CountryService : ICountryService
{
    private readonly Repository<Country> _countryRepository;

    public CountryService(Repository<Country> countryRepository)
    {
        _countryRepository = countryRepository;
    }

    public async Task<Country> CreateAsync(CountryDto model)
    {
        var country = ObjectMapper.Mapper.Map<Country>(model);
        await _countryRepository.CreateAsync(country);
        return country;
    }

    public async Task<List<Country>> GetAsync()
    {
        return await _countryRepository.GetAsync("Leagues", "Teams");
    }

    public async Task<Country> GetAsync(int id)
    {
        return await _countryRepository.GetAsync(id, "Leagues", "Teams");
    }

    public async Task<Country> UpdateAsync(Country model)
    {
        return await _countryRepository.UpdateAsync(model);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _countryRepository.DeleteAsync(id);
    }
}