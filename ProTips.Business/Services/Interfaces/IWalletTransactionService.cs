using ProTips.Entity.Models;

namespace ProTips.Business.Services.Interfaces;

public interface IWalletTransactionService : IService<WalletTransaction>
{
    Task<WalletTransaction> CreateAsync(WalletTransaction model);
}