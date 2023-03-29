using Microsoft.EntityFrameworkCore;
using ProTips.Entity.Database;
using ProTips.Entity.Models;

namespace ProTips.Entity.Repository;

public class CountryRepository : Repository<Country>
{
    public CountryRepository(MySqlContext context) : base(context)
    {
    }
}