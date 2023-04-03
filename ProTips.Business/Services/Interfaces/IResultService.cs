using ProTips.Business.Dtos;
using ProTips.Entity.Models;

namespace ProTips.Business.Services.Interfaces;

public interface IResultService : IService<Result>
{
    Task<Result> CreateAsync(ResultDto model);
}