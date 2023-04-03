using ProTips.Entity.Database;
using ProTips.Entity.Models;
using ProTips.Entity.Repository.Interfaces;

namespace ProTips.Entity.Repository;

public class BetRepository : Repository<Bet>, IBetRepository
{
    public BetRepository(MySqlContext context) : base(context)
    {
    }
}