using ProTips.Business.Configuration;
using ProTips.Business.Dtos;
using ProTips.Business.Services.Interfaces;
using ProTips.Entity.Models;
using ProTips.Entity.Repository;
using ProTips.Entity.Repository.Interfaces;

namespace ProTips.Business.Services;

public class WalletTransactionService : IWalletTransactionService
{
    private readonly IWalletTransactionRepository _walletTransactionRepository;
    public WalletTransactionService(IWalletTransactionRepository walletTransactionRepository)
    {
        _walletTransactionRepository = walletTransactionRepository;
    }

    public async Task<WalletTransaction> CreateAsync(WalletTransaction model)
    {
        var walletTransaction =  await _walletTransactionRepository.CreateAsync(model);
        return walletTransaction;
    }

    public async Task<List<WalletTransaction>> GetAsync()
    {
        return await _walletTransactionRepository.GetAsync();
    }

    public async Task<WalletTransaction> GetAsync(int id)
    {
        return await _walletTransactionRepository.GetAsync(id);
    }

    public async Task<WalletTransaction> UpdateAsync(WalletTransaction model)
    {
        return await _walletTransactionRepository.UpdateAsync(model);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _walletTransactionRepository.DeleteAsync(id);
    }
}