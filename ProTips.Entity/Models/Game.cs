using System.Text.Json.Serialization;

namespace ProTips.Entity.Models;

public class Game : Base
{
    [JsonIgnore] protected int HomeId { get; set; }
    public Team Home { get; set; }
    [JsonIgnore] protected int AwayId { get; set; }
    public Team Away { get; set; }
    [JsonIgnore] protected int ResultId { get; set; }
    public Result Result { get; set; }
}