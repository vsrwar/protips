namespace ProTips.Entity.Repository.Interfaces;

public interface IRepository<T> where T : Base
{
    Task<T> CreateAsync(T model);
    Task<List<T>> GetAsync();
    Task<T> GetAsync(int id);
    Task<T> UpdateAsync(T model);
    Task<bool> DeleteAsync(int id);
}