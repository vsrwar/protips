using System.Text.Json.Serialization;

namespace ProTips.Entity.Models;

public class Team : Base
{
    [JsonIgnore] protected int LeagueId { get; set; }
    public League League { get; set; }
    
    [JsonIgnore] protected int CountryId { get; set; }
    public Country Country { get; set; }
}