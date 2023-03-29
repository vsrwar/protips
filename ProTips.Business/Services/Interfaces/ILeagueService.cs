using ProTips.Business.Dtos;
using ProTips.Entity.Models;

namespace ProTips.Business.Services.Interfaces;

public interface ILeagueService 
{
    Task<League> CreateAsync(LeagueDto model);
    Task<List<League>> GetAsync();
    Task<League> GetAsync(int id);
    Task<League> UpdateAsync(League model);
    Task<bool> DeleteAsync(int id);
}