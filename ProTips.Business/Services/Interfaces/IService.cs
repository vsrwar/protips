using ProTips.Business.Dtos;
using ProTips.Entity;
using ProTips.Entity.Models;

namespace ProTips.Business.Services.Interfaces;

public interface IService<T> where T : Base
{
    Task<List<T>> GetAsync();
    Task<T> GetAsync(int id);
    Task<T> UpdateAsync(T model);
    Task<bool> DeleteAsync(int id);
}