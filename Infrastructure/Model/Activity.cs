namespace Infrastructure.Model;

public class Activity : BaseModel
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Address { get; set; }
    
    //Relationship with participations table
    public ICollection<Participation> Participations { get; set; }
    
    //Relationship with locations table
    public int LocationId { get; set; }
    public Location Location { get; set; }
}