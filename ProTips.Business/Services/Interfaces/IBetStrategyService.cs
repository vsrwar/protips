using ProTips.Business.Dtos;
using ProTips.Entity.Models;

namespace ProTips.Business.Services.Interfaces;

public interface IBetStrategyService : IService<BetStrategy>
{
    Task<BetStrategy> CreateAsync(BetStrategyDto model);
}