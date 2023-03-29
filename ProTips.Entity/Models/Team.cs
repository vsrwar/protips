using System.Text.Json.Serialization;

namespace ProTips.Entity.Models;

public class Team : Base
{
    public string Image { get; set; }
    [JsonIgnore] public int LeagueId { get; set; }
    public League League { get; set; }
    [JsonIgnore] public int CountryId { get; set; }
    public Country Country { get; set; }
}