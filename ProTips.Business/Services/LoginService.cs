using ProTips.Business.Configuration;
using ProTips.Business.Dtos;
using ProTips.Business.Services.Interfaces;

namespace ProTips.Business.Services;

public class LoginService : ILoginService
{
    private readonly IUserService _userService;
    private readonly IJwtProvider _jwtProvider;

    public LoginService(
        IUserService userService,
        IJwtProvider jwtProvider)
    {
        _userService = userService;
        _jwtProvider = jwtProvider;
    }

    public async Task<UserAuthenticated> LoginAsync(LoginDto login)
    {
        var user = await _userService.AuthenticateAsync(login.Email, login.Password);
        var response = ObjectMapper.Mapper.Map<UserAuthenticated>(user);
        response.Token = _jwtProvider.GenerateJwtToken(user);

        return response;
    }
}