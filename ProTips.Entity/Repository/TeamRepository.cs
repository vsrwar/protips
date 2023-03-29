using Microsoft.EntityFrameworkCore;
using ProTips.Entity.Database;
using ProTips.Entity.Models;
using ProTips.Entity.Repository.Interfaces;

namespace ProTips.Entity.Repository;

public class TeamRepository : Repository<Team>
{
    public TeamRepository(MySqlContext context) : base(context)
    {
    }
}