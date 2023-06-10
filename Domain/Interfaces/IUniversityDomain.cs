using Infrastructure.Model;

namespace Domain.Interfaces;

public interface IUniversityDomain
{
    List<University> GetAll();

    public University GetById(int id);

    bool Create(University universityData);

    bool Update(int id, University universityData);

    bool Delete(int id);
}