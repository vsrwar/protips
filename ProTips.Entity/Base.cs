namespace ProTips.Entity;

public class Base
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime CreationDate { get; set; } = DateTime.UtcNow;
    private DateTime? DeletedDate { get; set; }
    
    public bool IsDeleted => DeletedDate.HasValue;
}