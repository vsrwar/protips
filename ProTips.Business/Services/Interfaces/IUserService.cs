using ProTips.Business.Dtos;
using ProTips.Entity.Models;

namespace ProTips.Business.Services.Interfaces;

public interface IUserService : IService<User>
{
    Task<User> CreateAsync(UserDto model);
    Task<User> AuthenticateAsync(string loginEmail, string loginPassword);
}