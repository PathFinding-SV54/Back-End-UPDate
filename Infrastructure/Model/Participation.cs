namespace Infrastructure.Model;

public class Participation
{
    public int Id { get; set; }
    
    //Relationship with Activity
    public int ActivityId { get; set; }
    public Activity Activity { get; set; }
    
    //Relationship with GroupMember--
    //public int GroupMemberId { get; set; }
    //public GroupMember GroupMember { get; set; }
}