using Microsoft.EntityFrameworkCore;
using ProTips.Entity.Database;
using ProTips.Entity.Models;
using ProTips.Entity.Repository.Interfaces;

namespace ProTips.Entity.Repository;

public class WalletRepository : Repository<Wallet>, IWalletRepository
{
    public WalletRepository(MySqlContext context) : base(context)
    {
    }

    public async Task<Wallet> GetByUserIdAsync(int userId)
    {
        return await Context.Set<Wallet>()
            .Where(x =>
                x.DeletedDate.HasValue == false
                && x.UserId == userId
            )
            .AsNoTracking()
            .FirstOrDefaultAsync();
    }
}