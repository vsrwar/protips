using ProTips.Business.Dtos;
using ProTips.Entity.Models;

namespace ProTips.Business.Services.Interfaces;

public interface IBetService
{
    Task<Bet> CreateAsync(BetDto model);
    Task<List<Bet>> GetAsync();
    Task<Bet> GetAsync(int id);
    Task<Bet> UpdateAsync(Bet model);
    Task<bool> DeleteAsync(int id);
}