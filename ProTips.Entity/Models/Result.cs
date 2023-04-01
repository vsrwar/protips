using System.Text.Json.Serialization;
using ProTips.Entity.ValueObjects;

namespace ProTips.Entity.Models;

public class Result : Base
{
    public int HalfTimeGoalsHome { get; set; }
    public int HalfTimeGoalsAway { get; set; }
    public int FullTimeGoalsHome { get; set; }
    public int FullTimeGoalsAway { get; set; }
    [JsonIgnore] public int GameId { get; set; }
    public Game Game { get; set; }
}