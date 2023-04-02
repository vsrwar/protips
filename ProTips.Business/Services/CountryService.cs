using ProTips.Business.Configuration;
using ProTips.Business.Dtos;
using ProTips.Business.Services.Interfaces;
using ProTips.Entity.Models;
using ProTips.Entity.Repository;
using ProTips.Entity.Repository.Interfaces;

namespace ProTips.Business.Services;

public class CountryService : IService<Country>
{
    private readonly IRepository<Country> _countryRepository;

    public CountryService(IRepository<Country> countryRepository)
    {
        _countryRepository = countryRepository;
    }

    public async Task<Country> CreateAsync(dynamic model)
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