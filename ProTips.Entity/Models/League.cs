namespace ProTips.Entity.Models;

public class League : Base
{
    public int CountryId { get; set; }
    public ICollection<Team> Teams { get; set; }
    public string Image { get; set; }
}