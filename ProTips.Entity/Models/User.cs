using System.Text.Json.Serialization;
using ProTips.Entity.Utils;

namespace ProTips.Entity.Models;

public class User : Base
{
    public DateTime Birth { get; set; }
    public string Email { get; set; }
    [JsonIgnore] public string Password { get; set; }
    [JsonIgnore] public int WalletId { get; set; }
    public Wallet Wallet { get; set; }
    public ICollection<Bet> Bets { get; set; }
    
    public bool CheckPassword(string password)
    {
        return Encrypter.Encrypt(password) == Password;
    }
    
    public User EncryptPassword()
    {
        Password = Encrypter.Encrypt(Password);
        return this;
    }

    public User NewWallet(int currencyId)
    {
        Wallet = new Wallet() { CurrencyId = currencyId };
        return this;
    }
}