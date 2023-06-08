using Infrastructure.Model;

namespace Infrastructure.Interfaces;

public interface ICommunityInfrastructure
{
    List<Community> GetAll();
    public Community GetById(int id);
    bool Create(Community communityData);
    bool Update(int id, Community communityData);
    bool Delete(int id);
}