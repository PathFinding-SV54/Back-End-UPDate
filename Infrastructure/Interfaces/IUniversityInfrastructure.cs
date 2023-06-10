using Infrastructure.Model;

namespace Infrastructure.Interfaces;

public interface IUniversityInfrastructure
{
    List<University> GetAll();

    public University GetById(int id);

    bool Create(University universityData);

    bool Update(int id, University universityData);

    bool Delete(int id);
}