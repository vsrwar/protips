using ProTips.Entity.Database;
using ProTips.Entity.Models;
using ProTips.Entity.Repository.Interfaces;

namespace ProTips.Entity.Repository;

public class BetStrategyRepository : Repository<BetStrategy>, IBetStrategyRepository
{
    public BetStrategyRepository(MySqlContext context) : base(context)
    {
    }
}