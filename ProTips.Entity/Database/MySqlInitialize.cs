using ProTips.Entity.Models;

namespace ProTips.Entity.Database;

public static class MySqlInitialize
{
    public static async Task InitializeAsync(MySqlContext context)
    {
        context.Database.EnsureCreated();
        if (context.Teams.Any())
        {
            return;
        }
        
        var teams = new List<Team>()
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
        
        await context.Teams.AddRangeAsync(teams);
        await context.SaveChangesAsync();
    } 
}