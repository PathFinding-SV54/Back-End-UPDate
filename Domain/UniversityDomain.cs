using Domain.Interfaces;
using Infrastructure.Interfaces;
using Infrastructure.Model;

namespace Domain;

public class UniversityDomain : IUniversityDomain
{
    private IUniversityInfrastructure _universityInfrastructure;

    public UniversityDomain(IUniversityInfrastructure universityInfrastructure)
    {
        _universityInfrastructure = universityInfrastructure;
    }

    public List<University> GetAll()
    {
        return _universityInfrastructure.GetAll();
    }

    public University GetById(int id)
    {
        return _universityInfrastructure.GetById(id);
    }

    public bool Create(University universityData)
    {
        return _universityInfrastructure.Create(universityData);
    }

    public bool Update(int id, University universityData)
    {
        return _universityInfrastructure.Update(id, universityData);
    }

    public bool Delete(int id)
    {
        return _universityInfrastructure.Delete(id);
    }
}