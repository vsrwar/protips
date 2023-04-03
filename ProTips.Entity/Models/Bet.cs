using System.Text.Json.Serialization;

namespace ProTips.Entity.Models;

public class Bet : Base
{
    [JsonIgnore] public int UserId { get; set; }
    [JsonIgnore] public int GameId { get; set; }
    public Game Game { get; set; }
    public decimal Value { get; set; } = 0;
    public decimal Result { get; set; } = 0;
    public bool? Winner { get; set; }
    public decimal Odd { get; set; }
    [JsonIgnore] public int StrategyId { get; set; }
    public BetStrategy BetStrategy { get; set; }

    public void CalculateResult(bool winner)
    {
        Result = winner ? Value * Odd - Value : -Value;
    }

    public void GenerateName(Game game, BetStrategy betStrategy)
    {
        Name = $"{betStrategy?.Name} - {game?.Name} - {game?.Date.ToLocalTime().ToString("dd/MM/yyyy HH:mm")}";
    }
}