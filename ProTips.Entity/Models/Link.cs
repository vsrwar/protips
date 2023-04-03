using System.Text.Json.Serialization;

namespace ProTips.Entity.Models;

public class Link : Base
{
    public string Url { get; set; }
    public int GameId { get; set; }
}