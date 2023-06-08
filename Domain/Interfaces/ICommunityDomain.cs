using Infrastructure.DataClass;
using Infrastructure.Model;

namespace Domain;

public interface ICommunityDomain
{
    List<Community> GetAll();
    public Community GetById(int id);
    bool Create(CommunityData communityData); 
    bool Update(int id, CommunityData communityData );
    bool Delete(int id);
}