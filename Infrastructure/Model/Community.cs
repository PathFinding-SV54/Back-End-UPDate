namespace Infrastructure.Model;

public class Community : BaseModel
{
    public string Name { get; set; }
    public string Description { get; set; }
    
    //Relationship with CommunityMembers table
    public ICollection<CommunityMember> CommunityMembers { get; set; }
}