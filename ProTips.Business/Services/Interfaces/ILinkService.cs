using ProTips.Business.Dtos;
using ProTips.Entity.Models;

namespace ProTips.Business.Services.Interfaces;

public interface ILinkService : IService<Link>
{
    Task<Link> CreateAsync(LinkDto model);
    Task<List<Link>> CreateRangeAsync(List<Link> model);
}