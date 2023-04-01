using ProTips.Business.Configuration;
using ProTips.Business.Dtos;
using ProTips.Business.Services.Interfaces;
using ProTips.Entity.Models;
using ProTips.Entity.Repository;

namespace ProTips.Business.Services;

public class BetStrategyService : IBetStrategyService
{
    private readonly Repository<BetStrategy> _betStrategyRepository;

    public BetStrategyService(Repository<BetStrategy> betStrategyRepository)
    {
        _betStrategyRepository = betStrategyRepository;
    }

    public async Task<BetStrategy> CreateAsync(BetStrategy model)
    {
        await _betStrategyRepository.CreateAsync(model);
        return model;
    }

    public async Task<List<BetStrategy>> GetAsync()
    {
        return await _betStrategyRepository.GetAsync();
    }

    public async Task<BetStrategy> GetAsync(int id)
    {
        return await _betStrategyRepository.GetAsync(id);
    }

    public async Task<BetStrategy> UpdateAsync(BetStrategy model)
    {
        return await _betStrategyRepository.UpdateAsync(model);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _betStrategyRepository.DeleteAsync(id);
    }
}