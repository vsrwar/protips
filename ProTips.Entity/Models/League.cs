namespace ProTips.Entity.Models;

public class League : Base
{
    public int CountryId { get; set; }
    public List<Team> Teams { get; set; }
}