using System.Linq.Expressions;

namespace ProTips.Entity.Repository.Interfaces;

public interface IRepository<T> where T : Base
{
    Task<T> CreateAsync(T model);
    Task<List<T>> CreateRangeAsync(List<T> model);
    Task<List<T>> GetAsync(params string[] includes);
    Task<T> GetAsync(int id, params string[] includes);
    Task<T> UpdateAsync(T model);
    Task<bool> DeleteAsync(int id);
}