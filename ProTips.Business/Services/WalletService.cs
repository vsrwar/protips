using ProTips.Business.Configuration;
using ProTips.Business.Dtos;
using ProTips.Business.Services.Interfaces;
using ProTips.Entity.Models;
using ProTips.Entity.Repository;
using ProTips.Entity.Repository.Interfaces;
using ProTips.Entity.Utils;

namespace ProTips.Business.Services;

public class WalletService : IWalletService
{
    private readonly IWalletRepository _walletRepository;
    private readonly IWalletTransactionService _walletTransactionService;

    public WalletService(
        IWalletRepository walletRepository,
        IWalletTransactionService walletTransactionService
    )
    {
        _walletRepository = walletRepository;
        _walletTransactionService = walletTransactionService;
    }

    public async Task<Wallet> CreateAsync(Wallet model)
    {
        var wallet = await _walletRepository.CreateAsync(model);
        return wallet;
    }

    public async Task AddFundsAsync(int userId, decimal value)
    {
        var wallet = await _walletRepository.GetByUserIdAsync(userId);
        wallet.Balance += value;
        await _walletRepository.UpdateAsync(wallet);
        var transaction = await _walletTransactionService.CreateAsync(new WalletTransaction()
        {
            Amount = value,
            Operation = Operation.Deposit,
            WalletId = wallet.Id
        });
    }

    public async Task WithdrawFundsAsync(int userId, decimal value)
    {
        var wallet = await _walletRepository.GetByUserIdAsync(userId);
        if (wallet.Balance - value < 0)
        {
            throw new Exception("Insufficient funds");
        }
        
        wallet.Balance -= value;
        await _walletRepository.UpdateAsync(wallet);
        var transaction = await _walletTransactionService.CreateAsync(new WalletTransaction()
        {
            Amount = value,
            Operation = Operation.Withdraw,
            WalletId = wallet.Id
        });
    }

    public async Task AddBetResultAsync(int userId, decimal result)
    {
        var wallet = await _walletRepository.GetByUserIdAsync(userId);
        wallet.Balance += result;
        await _walletRepository.UpdateAsync(wallet);
        var transaction = await _walletTransactionService.CreateAsync(new WalletTransaction()
        {
            Amount = result,
            Operation = Operation.BetResult,
            WalletId = wallet.Id
        });
    }

    public async Task VerifySufficientFunds(int userId, decimal value)
    {
        var wallet = await _walletRepository.GetByUserIdAsync(userId);
        if (wallet.Balance - value < 0)
        {
            throw new Exception("Insufficient funds");
        }
    }

    public async Task<List<Wallet>> GetAsync()
    {
        return await _walletRepository.GetAsync();
    }

    public async Task<Wallet> GetAsync(int id)
    {
        return await _walletRepository.GetAsync(id);
    }

    public async Task<Wallet> UpdateAsync(Wallet model)
    {
        return await _walletRepository.UpdateAsync(model);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _walletRepository.DeleteAsync(id);
    }
}