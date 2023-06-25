namespace Infrastructure.Model;

public class Location : BaseModel
{
    public string LocationDescription { get; set; }
    
    public string LocationAddress { get; set; }
    
    //Relationship with Activity
    public ICollection<Activity> Activities { get; set; }
}