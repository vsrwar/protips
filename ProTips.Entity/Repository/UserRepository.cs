using ProTips.Entity.Database;
using ProTips.Entity.Models;
using ProTips.Entity.Repository.Interfaces;

namespace ProTips.Entity.Repository;

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(MySqlContext context) : base(context)
    {
    }
}