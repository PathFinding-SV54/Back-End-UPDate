using Infrastructure.DataClass;
using Infrastructure.Model;
using System.Collections.Generic;

namespace Domain;

public interface IUniversityDomain
{
    List<University> GetAll();
    public University GetById(int id);
    bool Create(UniversityData universityData);
    bool Update(int id, UniversityData universityData);
    bool Delete(int id);
}