using ProTips.Entity.Models;

namespace ProTips.Entity.Repository.Interfaces;

public interface IWalletRepository : IRepository<Wallet>
{
    Task<Wallet> GetByUserIdAsync(int userId);
}