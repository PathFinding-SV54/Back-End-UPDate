using Domain.Interfaces;
using Infrastructure.Interfaces;
using Infrastructure.Model;

namespace Domain;

public class CommunityDomain : ICommunityDomain
{
    private readonly ICommunityInfrastructure _communityInfrastructure;
    
    public CommunityDomain(ICommunityInfrastructure communityInfrastructure)
    {
        _communityInfrastructure = communityInfrastructure;
    }

    public List<Community> GetAll()
    {
        return _communityInfrastructure.GetAll();
    }

    public Community GetById(int id)
    {
        return _communityInfrastructure.GetById(id);
    }

    public bool Create(Community communityData)
    {
        return _communityInfrastructure.Create(communityData);
    }

    public bool Update(int id, Community communityData)
    {
        return _communityInfrastructure.Update(id, communityData);
    }

    public bool Delete(int id)
    {
        return _communityInfrastructure.Delete(id);
    }
}