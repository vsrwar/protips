using ProTips.Business.Configuration;
using ProTips.Business.Dtos;
using ProTips.Business.Services.Interfaces;
using ProTips.Entity.Models;
using ProTips.Entity.Repository;

namespace ProTips.Business.Services;

public class GameService : IGameService
{
    private readonly Repository<Game> _gameRepository;

    public GameService(Repository<Game> gameRepository)
    {
        _gameRepository = gameRepository;
    }

    public async Task<Game> CreateAsync(GameDto model)
    {
        var game = ObjectMapper.Mapper.Map<Game>(model);
        await _gameRepository.CreateAsync(game);
        return game;
    }

    public async Task<List<Game>> GetAsync()
    {
        return await _gameRepository.GetAsync("Home", "Away", "Result");
    }

    public async Task<Game> GetAsync(int id)
    {
        return await _gameRepository.GetAsync(id, "Home", "Away", "Result");
    }

    public async Task<Game> UpdateAsync(Game model)
    {
        return await _gameRepository.UpdateAsync(model);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _gameRepository.DeleteAsync(id);
    }
}