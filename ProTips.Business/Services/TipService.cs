using ProTips.Business.Configuration;
using ProTips.Business.Dtos;
using ProTips.Business.Services.Interfaces;
using ProTips.Entity.Models;
using ProTips.Entity.Repository;
using ProTips.Entity.Repository.Interfaces;

namespace ProTips.Business.Services;

public class TipService : ITipService
{
    private readonly ITipRepository _tipRepository;

    public TipService(ITipRepository tipRepository)
    {
        _tipRepository = tipRepository;
    }

    public async Task<Tip> CreateAsync(TipDto model)
    {
        var tip = ObjectMapper.Mapper.Map<Tip>(model);
        await _tipRepository.CreateAsync(tip);
        return tip;
    }

    public async Task<List<Tip>> GetAsync()
    {
        return await _tipRepository.GetAsync("Game", "PreLive", "BetStrategy");
    }

    public async Task<Tip> GetAsync(int id)
    {
        return await _tipRepository.GetAsync(id, "Game", "PreLive", "BetStrategy");
    }

    public async Task<Tip> UpdateAsync(Tip model)
    {
        return await _tipRepository.UpdateAsync(model);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _tipRepository.DeleteAsync(id);
    }
}