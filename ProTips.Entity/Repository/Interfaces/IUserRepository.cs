using ProTips.Entity.Models;

namespace ProTips.Entity.Repository.Interfaces;

public interface IUserRepository : IRepository<User>
{
    Task<User> GetByEmailAsync(string email, params string[] includes);
}