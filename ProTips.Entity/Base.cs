using System.Text.Json.Serialization;

namespace ProTips.Entity;

public abstract class Base
{
    public int Id { get; set; }
    public string Name { get; set; }
    [JsonIgnore] public DateTime CreationDate { get; set; } = DateTime.UtcNow;
    [JsonIgnore] public DateTime? DeletedDate { get; set; }
    [JsonIgnore] public bool IsDeleted => DeletedDate.HasValue;
}