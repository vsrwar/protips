using System.Text.Json.Serialization;

namespace ProTips.Entity.Models;

public class Wallet : Base
{
    public decimal Balance { get; set; }
    [JsonIgnore] public int UserId { get; set; }
    public ICollection<WalletTransaction> Transactions { get; set; }
    [JsonIgnore] public int CurrencyId { get; set; }
    public Currency Currency { get; set; }
}