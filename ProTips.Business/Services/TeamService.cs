using ProTips.Business.Configuration;
using ProTips.Business.Dtos;
using ProTips.Business.Services.Interfaces;
using ProTips.Entity.Models;
using ProTips.Entity.Repository;

namespace ProTips.Business.Services;

public class TeamService : ITeamService
{
    private readonly Repository<Team> _teamRepository;
    public TeamService(Repository<Team> teamRepository)
    {
        _teamRepository = teamRepository;
    }

    public Task<Team> CreateAsync(TeamDto model)
    {
        var team = ObjectMapper.Mapper.Map<Team>(model);
        return _teamRepository.CreateAsync(team);
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