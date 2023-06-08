using Infrastructure.Model;

namespace Infrastructure.Interfaces;

public interface IParticipationInfrastructure
{
    List<Participation> GetAll();
    public Participation GetById(int id);
    bool Create(Participation participationData);
    bool Update(int id, Participation participationData);
    bool Delete(int id);
}