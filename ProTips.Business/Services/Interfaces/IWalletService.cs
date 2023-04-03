using ProTips.Entity.Models;

namespace ProTips.Business.Services.Interfaces;

public interface IWalletService : IService<Wallet>
{
    Task<Wallet> CreateAsync(Wallet model);
    Task AddFundsAsync(int userId, decimal value);
    Task WithdrawFundsAsync(int userId, decimal value);
    Task AddBetResultAsync(int userId, decimal result);
    Task VerifySufficientFunds(int userId, decimal value);
}