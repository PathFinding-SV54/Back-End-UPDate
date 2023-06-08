namespace Infrastructure.Model;

public class Activity
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Address { get; set; }
    public DateTime Date { get; set; }
    
    public  bool IsActive { get; set; }
    
    //Relationship with Participations table
    public ICollection<Participation> Participations { get; set; }
    
}