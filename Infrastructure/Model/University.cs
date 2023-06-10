namespace Infrastructure.Model;

public class University
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public string WebSite { get; set; }
    
    public bool IsActive { get; set; }
    
    public ICollection<User> Users { get; set; }
}