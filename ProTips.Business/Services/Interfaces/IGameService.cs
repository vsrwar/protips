using ProTips.Business.Dtos;
using ProTips.Entity.Models;

namespace ProTips.Business.Services.Interfaces;

public interface IGameService : IService<Game>
{
    Task<Game> CreateAsync(GameDto model);
    Task<Game> UpdateResultAsync(int gameId, int resultId);
}