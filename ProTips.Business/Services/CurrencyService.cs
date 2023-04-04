using ProTips.Business.Configuration;
using ProTips.Business.Dtos;
using ProTips.Business.Services.Interfaces;
using ProTips.Entity.Models;
using ProTips.Entity.Repository;
using ProTips.Entity.Repository.Interfaces;

namespace ProTips.Business.Services;

public class CurrencyService : ICurrencyService
{
    private readonly ICurrencyRepository _currencyRepository;

    public CurrencyService(ICurrencyRepository currencyRepository)
    {
        _currencyRepository = currencyRepository;
    }

    public async Task<Currency> CreateAsync(CurrencyDto model)
    {
        var currency = ObjectMapper.Mapper.Map<Currency>(model);
        await _currencyRepository.CreateAsync(currency);
        return currency;
    }

    public async Task<List<Currency>> GetAsync()
    {
        return await _currencyRepository.GetAsync();
    }

    public async Task<Currency> GetAsync(int id)
    {
        return await _currencyRepository.GetAsync(id);
    }

    public async Task<Currency> UpdateAsync(Currency model)
    {
        return await _currencyRepository.UpdateAsync(model);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _currencyRepository.DeleteAsync(id);
    }
}