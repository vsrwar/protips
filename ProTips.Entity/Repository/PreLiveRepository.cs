using ProTips.Entity.Database;
using ProTips.Entity.Models;
using ProTips.Entity.Repository.Interfaces;

namespace ProTips.Entity.Repository;

public class PreLiveRepository : Repository<PreLive>, IPreLiveRepository
{
    public PreLiveRepository(MySqlContext context) : base(context)
    {
    }
}