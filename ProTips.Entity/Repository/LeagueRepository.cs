using Microsoft.EntityFrameworkCore;
using ProTips.Entity.Database;
using ProTips.Entity.Models;
using ProTips.Entity.Repository.Interfaces;

namespace ProTips.Entity.Repository;

public class LeagueRepository : Repository<League>, ILeagueRepository
{
    public LeagueRepository(MySqlContext context) : base(context)
    {
    }
}