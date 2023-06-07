using Infrastructure.Context;
using Infrastructure.DataClass;
using Infrastructure.Model;

namespace Infrastructure;

public class CommunityInfrastructure : ICommunityInfrastructure
{
    private UpdateDbContext _updateDbContext;
    
    public CommunityInfrastructure(UpdateDbContext updateDbContext)
    {
        _updateDbContext = updateDbContext;
    }

    public List<Community> GetAll()
    {
        return _updateDbContext.Communities.Where(community => community.IsActive).ToList();
    }

    public Community GetById(int id)
    {
        return _updateDbContext.Communities.Single(community => community.IsActive && community.Id == id);
    }

    public bool Create(CommunityData communityData)
    {
        try
        {
            var community = new Community();
            community.Name = communityData.Name;
            community.Description = communityData.Description;
            community.IsActive = true;
            
            _updateDbContext.Communities.Add(community);
            _updateDbContext.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }

    public bool Update(int id, CommunityData communityData)
    {
        try
        {
            var community = _updateDbContext.Communities.Find(id);

            community.Name = communityData.Name;
            community.Description = communityData.Description;

            _updateDbContext.Communities.Update(community);
            _updateDbContext.SaveChanges();

            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }

    public bool Delete(int id)
    {
        var community = _updateDbContext.Communities.Find(id);
        community.IsActive = false;

        _updateDbContext.Communities.Update(community);
        _updateDbContext.SaveChanges();
        
        return true;
    }
}