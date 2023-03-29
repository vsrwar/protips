using ProTips.Business.Services.Interfaces;
using ProTips.Entity.Models;
using ProTips.Entity.Repository;
using ProTips.Entity.Repository.Interfaces;

namespace ProTips.Business.Services;

public class TeamService : ITeamService
{
    private readonly Repository<Team> _teamRepository;
    public TeamService(Repository<Team> teamRepository)
    {
        _teamRepository = teamRepository;
    }
    
    public async Task<List<Team>> GetAsync()
    {
        return await _teamRepository.GetAsync();
    }

    public async Task<Team> GetAsync(int id)
    {
        return await _teamRepository.GetAsync(id);
    }
}