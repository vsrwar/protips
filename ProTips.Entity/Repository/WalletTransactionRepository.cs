using ProTips.Entity.Database;
using ProTips.Entity.Models;
using ProTips.Entity.Repository.Interfaces;

namespace ProTips.Entity.Repository;

public class WalletTransactionRepository : Repository<WalletTransaction>, IWalletTransactionRepository
{
    public WalletTransactionRepository(MySqlContext context) : base(context)
    {
    }
}