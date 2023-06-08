using Infrastructure.DataClass;
using Infrastructure.Model;

namespace Infrastructure;

public interface IParticipationInfrastructure
{
    List<Participation> GetAll();
    public Participation GetById(int id);
    bool Create(ParticipationData participationData);
    bool Update(int id, ParticipationData participationData);
    bool Delete(int id);
}