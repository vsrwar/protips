using ProTips.Entity.ValueObjects;

namespace ProTips.Business.Dtos;

public class ResultDto
{
    public HalfTimeGols HalfTimeGols { get; set; }
    public FullTimeGols FullTimeGols { get; set; }
    public int GameId { get; set; }
    public string Name { get { return $"{FullTimeGols.Home} x {FullTimeGols.Away}"; } }
}