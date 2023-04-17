using ProTips.Entity.Models;

namespace ProTips.Business.Services.Interfaces;

public interface IJwtProvider
{
    string GenerateJwtToken(User user);
}