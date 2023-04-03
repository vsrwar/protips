using ProTips.Business.Dtos;
using ProTips.Entity.Models;
using ProTips.Entity.Repository.Interfaces;

namespace ProTips.Business.Services.Interfaces;

public interface IBetService : IService<Bet>
{
    Task<Bet> CreateAsync(BetDto model);
    Task<Bet> WinnerAsync(int id, bool winner);
}