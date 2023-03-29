using ProTips.Entity.Models;

namespace ProTips.Business.Services.Interfaces;

public interface ITeamService
{
    Task<List<Team>> GetAsync();
    Task<Team> GetAsync(int id); 
}