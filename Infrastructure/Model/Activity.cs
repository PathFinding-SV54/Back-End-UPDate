namespace Infrastructure.Model;

public class Activity : BaseModel
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Address { get; set; }
    
    //Relationship with Participations table
    public ICollection<Participation> Participations { get; set; }
    
}