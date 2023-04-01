using ProTips.Entity.Database;
using ProTips.Entity.Models;

namespace ProTips.Entity.Repository;

public class ResultRepository : Repository<Result>
{
    public ResultRepository(MySqlContext context) : base(context)
    {
    }
}