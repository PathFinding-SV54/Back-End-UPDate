namespace Infrastructure.Model;

public class BaseModel
{
    public int Id { get; set; }
    public DateTime? CreatedAt { get; set; }
    
    public bool IsActive { get; set; }
}