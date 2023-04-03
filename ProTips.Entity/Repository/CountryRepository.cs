using Microsoft.EntityFrameworkCore;
using ProTips.Entity.Database;
using ProTips.Entity.Models;
using ProTips.Entity.Repository.Interfaces;

namespace ProTips.Entity.Repository;

public class CountryRepository : Repository<Country>, ICountryRepository
{
    public CountryRepository(MySqlContext context) : base(context)
    {
    }
}