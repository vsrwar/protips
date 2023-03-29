using ProTips.Business.Dtos;
using ProTips.Entity.Models;

namespace ProTips.Business.Services.Interfaces;

public interface ITeamService
{
    Task<Team> CreateAsync(TeamDto model);
    Task<List<Team>> GetAsync();
    Task<Team> GetAsync(int id);
    Task<Team> UpdateAsync(Team model);
    Task<bool> DeleteAsync(int id);
}