using System.Text.Json.Serialization;

namespace ProTips.Entity.Models;

public class User : Base
{
    public DateTime Birth { get; set; }
    public string Email { get; set; }
    [JsonIgnore] public string Password { get; set; }
    [JsonIgnore] public int WalletId { get; set; }
    public Wallet Wallet { get; set; }
    public ICollection<Bet> Bets { get; set; }
}