using ProTips.Entity.Database;
using ProTips.Entity.Models;
using ProTips.Entity.Repository.Interfaces;

namespace ProTips.Entity.Repository;

public class ResultRepository : Repository<Result>, IResultRepository
{
    public ResultRepository(MySqlContext context) : base(context)
    {
    }
}