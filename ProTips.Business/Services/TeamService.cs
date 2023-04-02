using ProTips.Business.Configuration;
using ProTips.Business.Dtos;
using ProTips.Business.Services.Interfaces;
using ProTips.Entity.Models;
using ProTips.Entity.Repository;
using ProTips.Entity.Repository.Interfaces;

namespace ProTips.Business.Services;

public class TeamService : IService<Team>
{
    private readonly IRepository<Team> _teamRepository;
    public TeamService(IRepository<Team> teamRepository)
    {
        _teamRepository = teamRepository;
    }

    public Task<Team> CreateAsync(dynamic model)
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