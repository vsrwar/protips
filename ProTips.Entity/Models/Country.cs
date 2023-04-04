namespace ProTips.Entity.Models;

public class Country : Base
{
    public ICollection<Team> Teams { get; set; }
    public ICollection<League> Leagues { get; set; }
    public string Image { get; set; }
}