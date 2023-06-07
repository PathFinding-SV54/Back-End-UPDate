using Infrastructure.DataClass;
using Infrastructure.Model;

namespace Infrastructure;

public interface ICommunityInfrastructure
{
    List<Community> GetAll();
    public Community GetById(int id);
    bool Create(CommunityData communityData);
    bool Update(int id, CommunityData communityData);
    bool Delete(int id);
}