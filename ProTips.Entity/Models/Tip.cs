using System.Text.Json.Serialization;

namespace ProTips.Entity.Models;

public class Tip : Base
{
    [JsonIgnore] public int GameId { get; set; }
    public Game Game { get; set; }
    [JsonIgnore] public int BetStrategyId { get; set; }
    public BetStrategy BetStrategy { get; set; }
    [JsonIgnore] public int PreLiveId { get; set; }
    public PreLive PreLive { get; set; }
}