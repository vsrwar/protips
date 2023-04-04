using ProTips.Business.Configuration;
using ProTips.Business.Dtos;
using ProTips.Business.Services.Interfaces;
using ProTips.Entity.Models;
using ProTips.Entity.Repository;
using ProTips.Entity.Repository.Interfaces;

namespace ProTips.Business.Services;

public class BetStrategyService : IBetStrategyService
{
    private readonly IBetStrategyRepository _betStrategyRepository;

    public BetStrategyService(IBetStrategyRepository betStrategyRepository)
    {
        _betStrategyRepository = betStrategyRepository;
    }

    public async Task<BetStrategy> CreateAsync(BetStrategyDto model)
    {
        var strategy = ObjectMapper.Mapper.Map<BetStrategy>(model);
        await _betStrategyRepository.CreateAsync(strategy);
        return strategy;
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