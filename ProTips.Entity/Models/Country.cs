namespace ProTips.Entity.Models;

public class Country : Base
{
    public List<Team> Teams { get; set; }
}