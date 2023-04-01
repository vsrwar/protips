using ProTips.Entity.Database;
using ProTips.Entity.Models;

namespace ProTips.Entity.Repository;

public class BetRepository : Repository<Bet>
{
    public BetRepository(MySqlContext context) : base(context)
    {
    }
}