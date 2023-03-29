using System.Text.Json.Serialization;

namespace ProTips.Entity.Models;

public class Team : Base
{
    public string Image { get; set; }
    public int LeagueId { get; set; }
    public int CountryId { get; set; }
}