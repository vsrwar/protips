using ProTips.Entity.Database;
using ProTips.Entity.Models;
using ProTips.Entity.Repository.Interfaces;

namespace ProTips.Entity.Repository;

public class TipRepository : Repository<Tip>, ITipRepository
{
    public TipRepository(MySqlContext context) : base(context)
    {
    }
}