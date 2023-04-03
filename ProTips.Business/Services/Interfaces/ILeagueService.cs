using ProTips.Business.Dtos;
using ProTips.Entity.Models;

namespace ProTips.Business.Services.Interfaces;

public interface ILeagueService : IService<League>
{
     Task<League> CreateAsync(LeagueDto model);
}