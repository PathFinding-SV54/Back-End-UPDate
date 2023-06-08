using Infrastructure.Model;

namespace Domain.Interfaces;

public interface ICommunityDomain
{
    List<Community> GetAll();
    public Community GetById(int id);
    bool Create(Community communityData); 
    bool Update(int id, Community communityData );
    bool Delete(int id);
}