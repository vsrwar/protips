using ProTips.Business.Configuration;
using ProTips.Business.Dtos;
using ProTips.Business.Services.Interfaces;
using ProTips.Entity.Models;
using ProTips.Entity.Repository;
using ProTips.Entity.Repository.Interfaces;

namespace ProTips.Business.Services;

public class ResultService : IResultService
{
    private readonly IResultRepository _resultRepository;
    private readonly IGameService _gameService;

    public ResultService(
        IResultRepository resultRepository,
        IGameService gameService)
    {
        _resultRepository = resultRepository;
        _gameService = gameService;
    }

    public async Task<Result> CreateAsync(ResultDto model)
    {
        var result = ObjectMapper.Mapper.Map<Result>(model);
        await _resultRepository.CreateAsync(result);
        await _gameService.UpdateResultAsync(model.GameId, result.Id);
        
        return result;
    }

    public async Task<List<Result>> GetAsync()
    {
        return await _resultRepository.GetAsync("Game");
    }

    public async Task<Result> GetAsync(int id)
    {
        return await _resultRepository.GetAsync(id, "Game");
    }

    public async Task<Result> UpdateAsync(Result model)
    {
        return await _resultRepository.UpdateAsync(model);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _resultRepository.DeleteAsync(id);
    }
}