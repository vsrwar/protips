using Microsoft.EntityFrameworkCore;
using ProTips.Entity.Database;
using ProTips.Entity.Models;

namespace ProTips.Entity.Repository;

public class LeagueRepository : Repository<League>
{
    public LeagueRepository(MySqlContext context) : base(context)
    {
    }
}