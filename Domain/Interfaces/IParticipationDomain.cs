using Infrastructure.Model;

namespace Domain.Interfaces;

public interface IParticipationDomain
{
    List<Participation> GetAll();
    public Participation GetById(int id);
    bool Create(Participation participationData);
    bool Update(int id, Participation participationData);
    bool Delete(int id);
}