using Microsoft.EntityFrameworkCore;
using ProTips.Entity.Database;
using ProTips.Entity.Models;
using ProTips.Entity.Repository.Interfaces;
using ProTips.Entity.Utils;

namespace ProTips.Entity.Repository;

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(MySqlContext context) : base(context)
    {
    }
    
    public async Task<User> GetByEmailAsync(string email, params string[] includes) =>
        await Context.Set<User>()
            .IncludeIf(includes.Any(), includes)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => 
                x.Email == email
                && x.DeletedDate.HasValue == false);
}