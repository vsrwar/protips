using ProTips.Entity.Database;
using ProTips.Entity.Models;
using ProTips.Entity.Repository.Interfaces;

namespace ProTips.Entity.Repository;

public class GameRepository : Repository<Game>, IGameRepository
{
    public GameRepository(MySqlContext context) : base(context)
    {
    }
}