using ProTips.Business.Dtos;

namespace ProTips.Business.Services.Interfaces;

public interface ILoginService
{
    Task<UserAuthenticated> LoginAsync(LoginDto login);
}