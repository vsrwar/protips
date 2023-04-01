using ProTips.Business.Configuration;
using ProTips.Business.Dtos;
using ProTips.Business.Services.Interfaces;
using ProTips.Entity.Models;
using ProTips.Entity.Repository;

namespace ProTips.Business.Services;

public class BetService : IBetService
{
    private readonly Repository<Bet> _betRepository;

    public BetService(Repository<Bet> betRepository)
    {
        _betRepository = betRepository;
    }

    public async Task<Bet> CreateAsync(BetDto model)
    {
        var bet = ObjectMapper.Mapper.Map<Bet>(model);
        await _betRepository.CreateAsync(bet);
        return bet;
    }

    public async Task<List<Bet>> GetAsync()
    {
        return await _betRepository.GetAsync("Game", "BetStrategy");
    }

    public async Task<Bet> GetAsync(int id)
    {
        return await _betRepository.GetAsync(id, "Game", "BetStrategy");
    }

    public async Task<Bet> UpdateAsync(Bet model)
    {
        return await _betRepository.UpdateAsync(model);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _betRepository.DeleteAsync(id);
    }
}