using ProTips.Business.Dtos;
using ProTips.Entity.Models;

namespace ProTips.Business.Services.Interfaces;

public interface IResultService
{
    Task<Result> CreateAsync(ResultDto model);
    Task<List<Result>> GetAsync();
    Task<Result> GetAsync(int id);
    Task<Result> UpdateAsync(Result model);
    Task<bool> DeleteAsync(int id);
}