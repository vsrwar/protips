using ProTips.Business.Configuration;
using ProTips.Business.Dtos;
using ProTips.Business.Services.Interfaces;
using ProTips.Entity.Models;
using ProTips.Entity.Repository;
using ProTips.Entity.Repository.Interfaces;

namespace ProTips.Business.Services;

public class PreLiveService : IPreLiveService
{
    private readonly IPreLiveRepository _preLiveRepository;

    public PreLiveService(IPreLiveRepository preLiveRepository)
    {
        _preLiveRepository = preLiveRepository;
    }

    public async Task<PreLive> CreateAsync(PreLiveDto model)
    {
        var preLive = ObjectMapper.Mapper.Map<PreLive>(model);
        await _preLiveRepository.CreateAsync(preLive);
        return preLive;
    }

    public async Task<List<PreLive>> GetAsync()
    {
        return await _preLiveRepository.GetAsync("Game", "Game.Home", "Game.Away", "Game.Result", "Game.Links");
    }

    public async Task<PreLive> GetAsync(int id)
    {
        return await _preLiveRepository.GetAsync(id, "Game", "Game.Home", "Game.Away", "Game.Result", "Game.Links");
    }

    public async Task<PreLive> UpdateAsync(PreLive model)
    {
        return await _preLiveRepository.UpdateAsync(model);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _preLiveRepository.DeleteAsync(id);
    }
}