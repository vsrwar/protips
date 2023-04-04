using ProTips.Entity.Models;

namespace ProTips.Business.Dtos;

public class TeamDto
{
    public string Name { get; set; }
    public string Image { get; set; }
    public int CountryId { get; set; }
    public int LeagueId { get; set; }
}