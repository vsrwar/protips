using ProTips.Entity.Models;

namespace ProTips.Business.Services.Interfaces;

public interface IBetStrategyService : IService<BetStrategy>
{
    Task<BetStrategy> CreateAsync(BetStrategy model);
}