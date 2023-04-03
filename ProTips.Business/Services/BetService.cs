using ProTips.Business.Configuration;
using ProTips.Business.Dtos;
using ProTips.Business.Services.Interfaces;
using ProTips.Entity.Models;
using ProTips.Entity.Repository;
using ProTips.Entity.Repository.Interfaces;

namespace ProTips.Business.Services;

public class BetService : IBetService
{
    private readonly IBetRepository _betRepository;
    private readonly IGameService _gameService;
    private readonly IBetStrategyService _betStrategyService;
    private readonly IWalletService _walletService;

    public BetService(
        IBetRepository betRepository,
        IGameService gameService,
        IBetStrategyService betStrategyService,
        IWalletService walletService
    )
    {
        _betRepository = betRepository;
        _gameService = gameService;
        _betStrategyService = betStrategyService;
        _walletService = walletService;
    }

    public async Task<Bet> CreateAsync(BetDto model)
    {
        var bet = ObjectMapper.Mapper.Map<Bet>(model);
        
        await _walletService.VerifySufficientFunds(bet.UserId, bet.Value);
        
        var game = await _gameService.GetAsync(model.GameId);
        var betStrategy = await _betStrategyService.GetAsync(model.StrategyId);
        
        bet.GenerateName(game, betStrategy);
        
        await _betRepository.CreateAsync(bet);
        return bet;
    }

    public async Task<Bet> WinnerAsync(int id, bool winner)
    {
        var bet = await _betRepository.GetAsync(id);
        bet.Winner = winner;
        bet.CalculateResult(winner);
        
        await _walletService.AddBetResultAsync(bet.UserId, bet.Result);
        
        return await _betRepository.UpdateAsync(bet);
    }

    public async Task<List<Bet>> GetAsync()
    {
        return await _betRepository.GetAsync("Game", "Game.Home", "Game.Away", "Game.Links", "Game.Result", "BetStrategy");
    }

    public async Task<Bet> GetAsync(int id)
    {
        return await _betRepository.GetAsync(id, "Game", "Game.Home", "Game.Away", "Game.Links", "Game.Result", "BetStrategy");
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