using ProTips.Business.Configuration;
using ProTips.Business.Dtos;
using ProTips.Business.Services.Interfaces;
using ProTips.Entity.Models;
using ProTips.Entity.Repository;
using ProTips.Entity.Repository.Interfaces;

namespace ProTips.Business.Services;

public class TeamService : ITeamService
{
    private readonly ITeamRepository _teamRepository;
    public TeamService(ITeamRepository teamRepository)
    {
        _teamRepository = teamRepository;
    }

    public async Task<Team> CreateAsync(TeamDto model)
    {
        var team = ObjectMapper.Mapper.Map<Team>(model);
        await _teamRepository.CreateAsync(team);
        return team;
    }

    public async Task<List<Team>> GetAsync()
    {
        return await _teamRepository.GetAsync();
    }

    public async Task<Team> GetAsync(int id)
    {
        return await _teamRepository.GetAsync(id);
    }

    public async Task<Team> UpdateAsync(Team model)
    {
        return await _teamRepository.UpdateAsync(model);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _teamRepository.DeleteAsync(id);
    }
}