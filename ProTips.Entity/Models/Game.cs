using System.Text.Json.Serialization;

namespace ProTips.Entity.Models;

public class Game : Base
{
    [JsonIgnore] public int HomeId { get; set; }
    public Team Home { get; set; }
    [JsonIgnore] public int AwayId { get; set; }
    public Team Away { get; set; }
    [JsonIgnore] public int? ResultId { get; set; }
    public Result Result { get; set; }
    public DateTime Date { get; set; }
}