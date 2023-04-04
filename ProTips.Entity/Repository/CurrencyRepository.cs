using ProTips.Entity.Database;
using ProTips.Entity.Models;
using ProTips.Entity.Repository.Interfaces;

namespace ProTips.Entity.Repository;

public class CurrencyRepository : Repository<Currency>, ICurrencyRepository
{
    public CurrencyRepository(MySqlContext context) : base(context)
    {
    }
}