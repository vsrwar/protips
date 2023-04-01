namespace ProTips.Business.Dtos;

public class BetDto
{
    public int GameId { get; set; }
    public decimal Value { get; set; } = 0;
    public bool? Winner { get; set; }
    public decimal Odd { get; set; }
    public int StrategyId { get; set; }
    public string Name { get { return $"{StrategyId} - {DateTime.UtcNow.ToString("dd/MM/yyyy HH:mm")}"; } }
}