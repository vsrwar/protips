using ProTips.Entity.Models;
using ProTips.Entity.Repository.Interfaces;

namespace ProTips.Entity.Repository;

public class TeamRepository : IRepository<Team>
{
    public async Task<Team> CreateAsync(Team model)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Team>> GetAsync()
    {
        return new List<Team>()
        {
            new()
            {
                Id = 1,
                Country = new Country()
                {
                    Id = 1, Name = "Brazil", CreationDate = DateTime.UtcNow
                },
                League = new League()
                {
                    Id = 1,
                    Name = "Série A",
                    CreationDate = DateTime.UtcNow
                },
                Name = "São Paulo",
                CreationDate = DateTime.UtcNow
            },
            new()
            {
                Id = 2,
                Country = new Country()
                {
                    Id = 1, Name = "Brazil", CreationDate = DateTime.UtcNow
                },
                League = new League()
                {
                    Id = 1,
                    Name = "Série A",
                    CreationDate = DateTime.UtcNow
                },
                Name = "Corinthians",
                CreationDate = DateTime.UtcNow
            },
        };
    }

    public async Task<Team> GetAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<Team> UpdateAsync(Team model)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}