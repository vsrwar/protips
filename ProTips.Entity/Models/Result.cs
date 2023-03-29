using System.Text.Json.Serialization;

namespace ProTips.Entity.Models;

public class Result : Base
{
    public int GoalsHome { get; set; } = 0;
    public int GoalsAway { get; set;  } = 0;
    public Game Game { get; set; }
}