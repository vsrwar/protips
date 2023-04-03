using ProTips.Entity.Models;

namespace ProTips.Business.Services.Interfaces;

public interface ILinkService : IService<Link>
{
    Task<Link> CreateAsync(Link model);
    Task<List<Link>> CreateRangeAsync(List<Link> model);
}