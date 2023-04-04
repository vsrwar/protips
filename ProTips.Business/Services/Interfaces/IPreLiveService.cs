using ProTips.Business.Dtos;
using ProTips.Entity.Models;

namespace ProTips.Business.Services.Interfaces;

public interface IPreLiveService : IService<PreLive>
{
    Task<PreLive> CreateAsync(PreLiveDto model);
}