using ProTips.Entity.Database;
using ProTips.Entity.Models;

namespace ProTips.Entity.Repository;

public class BetStrategyRepository : Repository<BetStrategy>
{
    public BetStrategyRepository(MySqlContext context) : base(context)
    {
    }
}