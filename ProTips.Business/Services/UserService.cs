using ProTips.Business.Configuration;
using ProTips.Business.Dtos;
using ProTips.Business.Services.Interfaces;
using ProTips.Entity.Models;
using ProTips.Entity.Repository.Interfaces;

namespace ProTips.Business.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> CreateAsync(UserDto model)
    {
        if (!model.HasValidConfirmationPassword())
        {
            throw new Exception("Passwords do not match");
        }
        
        var user = ObjectMapper.Mapper.Map<User>(model);
        user.NewWallet(model.CurrencyId)
            .EncryptPassword();
        await _userRepository.CreateAsync(user);
        user.WalletId = user.Wallet.Id;
        await _userRepository.UpdateAsync(user);
        return user;
    }

    public async Task<User> AuthenticateAsync(string loginEmail, string loginPassword)
    {
        var user = await _userRepository.GetByEmailAsync(loginEmail);
        if (user == null)
        {
            throw new Exception("Email ou Senha incorreto(s).");
        }

        if (!user.CheckPassword(loginPassword))
        {
            throw new Exception("Email ou Senha incorreto(s).");
        }
        
        return user;
    }

    public async Task<List<User>> GetAsync()
    {
        return await _userRepository.GetAsync("Wallet", "Wallet.Transactions", "Wallet.Currency");
    }

    public async Task<User> GetAsync(int id)
    {
        return await _userRepository.GetAsync(id, "Wallet", "Wallet.Transactions", "Wallet.Currency");
    }

    public async Task<User> UpdateAsync(User model)
    {
        return await _userRepository.UpdateAsync(model);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _userRepository.DeleteAsync(id);
    }
}