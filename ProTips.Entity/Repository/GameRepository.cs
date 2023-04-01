using ProTips.Entity.Database;
using ProTips.Entity.Models;

namespace ProTips.Entity.Repository;

public class GameRepository : Repository<Game>
{
    public GameRepository(MySqlContext context) : base(context)
    {
    }
}