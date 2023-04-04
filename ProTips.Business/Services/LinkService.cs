using ProTips.Business.Configuration;
using ProTips.Business.Dtos;
using ProTips.Business.Services.Interfaces;
using ProTips.Entity.Models;
using ProTips.Entity.Repository;
using ProTips.Entity.Repository.Interfaces;

namespace ProTips.Business.Services;

public class LinkService : ILinkService
{
    private readonly ILinkRepository _linkRepository;

    public LinkService(ILinkRepository linkRepository)
    {
        _linkRepository = linkRepository;
    }

    public async Task<Link> CreateAsync(LinkDto model)
    {
        var link = ObjectMapper.Mapper.Map<Link>(model);
        await _linkRepository.CreateAsync(link);
        return link;
    }

    public async Task<List<Link>> CreateRangeAsync(List<Link> model)
    {
        await _linkRepository.CreateRangeAsync(model);
        return model;
    }

    public async Task<List<Link>> GetAsync()
    {
        return await _linkRepository.GetAsync();
    }

    public async Task<Link> GetAsync(int id)
    {
        return await _linkRepository.GetAsync(id);
    }

    public async Task<Link> UpdateAsync(Link model)
    {
        return await _linkRepository.UpdateAsync(model);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _linkRepository.DeleteAsync(id);
    }
}