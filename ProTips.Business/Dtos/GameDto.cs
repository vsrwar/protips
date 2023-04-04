using ProTips.Entity.Models;

namespace ProTips.Business.Dtos;

public class GameDto
{
    public int HomeId { get; set; }
    public int AwayId { get; set; }
    public int? ResultId { get; set; }
    public DateTime Date { get; set; }
    public List<LinkDto> Links { get; set; }
    public string Name { get { return $"{HomeId} vs {AwayId}"; } }
}