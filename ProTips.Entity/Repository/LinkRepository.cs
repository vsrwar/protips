using ProTips.Entity.Database;
using ProTips.Entity.Models;
using ProTips.Entity.Repository.Interfaces;

namespace ProTips.Entity.Repository;

public class LinkRepository : Repository<Link>, ILinkRepository
{
    public LinkRepository(MySqlContext context) : base(context)
    {
    }
}