using ProTips.Business.Dtos;
using ProTips.Entity.Models;

namespace ProTips.Business.Services.Interfaces;

public interface IGameService
{
    Task<Game> CreateAsync(GameDto model);
    Task<List<Game>> GetAsync();
    Task<Game> GetAsync(int id);
    Task<Game> UpdateAsync(Game model);
    Task<bool> DeleteAsync(int id);
}