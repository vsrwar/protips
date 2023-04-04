using ProTips.Business.Dtos;
using ProTips.Entity.Models;

namespace ProTips.Business.Services.Interfaces;

public interface ITipService : IService<Tip>
{
    Task<Tip> CreateAsync(TipDto model);
}