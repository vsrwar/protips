﻿using ProTips.Business.Configuration;
using ProTips.Business.Dtos;
using ProTips.Business.Services.Interfaces;
using ProTips.Entity.Models;
using ProTips.Entity.Repository;
using ProTips.Entity.Repository.Interfaces;

namespace ProTips.Business.Services;

public class LeagueService : IService<League>
{
    private readonly IRepository<League> _leagueRepository;

    public LeagueService(IRepository<League> leagueRepository)
    {
        _leagueRepository = leagueRepository;
    }

    public async Task<League> CreateAsync(dynamic model)
    {
        var league = ObjectMapper.Mapper.Map<League>(model);
        await _leagueRepository.CreateAsync(league);
        return league;
    }

    public async Task<List<League>> GetAsync()
    {
        return await _leagueRepository.GetAsync("Teams");
    }

    public async Task<League> GetAsync(int id)
    {
        return await _leagueRepository.GetAsync(id, "Teams");
    }

    public async Task<League> UpdateAsync(League model)
    {
        return await _leagueRepository.UpdateAsync(model);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _leagueRepository.DeleteAsync(id);
    }
}