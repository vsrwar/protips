using ProTips.Business.Dtos;
using ProTips.Entity.Models;

namespace ProTips.Business.Services.Interfaces;

public interface IBetStrategyService
{
    Task<BetStrategy> CreateAsync(BetStrategy model);
    Task<List<BetStrategy>> GetAsync();
    Task<BetStrategy> GetAsync(int id);
    Task<BetStrategy> UpdateAsync(BetStrategy model);
    Task<bool> DeleteAsync(int id);
}