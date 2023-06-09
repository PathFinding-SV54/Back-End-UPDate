namespace Infrastructure.Model;

public class Location : BaseModel
{
    public string Description { get; set; }
    
    //Relationship with Activity
    public ICollection<Activity> Activities { get; set; }
}