using Infrastructure.DataClass;
using Infrastructure.Model;

namespace Domain;

public interface IParticipationDomain
{
    List<Participation> GetAll();
    public Participation GetById(int id);
    bool Create(ParticipationData participationData);
    bool Update(int id, ParticipationData participationData);
    bool Delete(int id);
}