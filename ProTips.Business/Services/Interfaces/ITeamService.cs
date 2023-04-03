using ProTips.Business.Dtos;
using ProTips.Entity.Models;

namespace ProTips.Business.Services.Interfaces;

public interface ITeamService : IService<Team>
{
    Task<Team> CreateAsync(TeamDto model);
}