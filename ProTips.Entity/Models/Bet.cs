using System.Text.Json.Serialization;

namespace ProTips.Entity.Models;

public class Bet : Base
{
    [JsonIgnore] public int GameId { get; set; }
    public Game Game { get; set; }
    public decimal Value { get; set; } = 0;
    public decimal Result { get; set; } = 0;
    public decimal Odd { get; set; }
    [JsonIgnore] protected int StrategyId { get; set; }
    public BetStrategy BetStrategy { get; set; }
}