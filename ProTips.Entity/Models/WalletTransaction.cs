using System.Text.Json.Serialization;
using ProTips.Entity.Utils;

namespace ProTips.Entity.Models;

public class WalletTransaction : Base
{
    [JsonIgnore] public int WalletId { get; set; }
    public Operation Operation { get; set; }
    public decimal Amount { get; set; }
}