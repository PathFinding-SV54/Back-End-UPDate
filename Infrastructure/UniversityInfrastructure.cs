using Infrastructure.Interfaces;
using Infrastructure.Model;
using Infrastructure.Context;

namespace Infrastructure;

public class UniversityInfrastructure : IUniversityInfrastructure
{
    private readonly UpdateDbContext _updateDbContext;

    public UniversityInfrastructure(UpdateDbContext updateDbContext)
    {
        _updateDbContext = updateDbContext;
    }

    public List<University> GetAll()
    {
        return _updateDbContext.Universities.Where(university => university.isActive).ToList();
    }

    public University GetById(int id)
    {
        return _updateDbContext.Universities.Single(university => university.Id == id);
    }

    public bool Create(University universityData)
    {
        try
        {
            universityData.isActive = true;
            _updateDbContext.Universities.Add(universityData);
            _updateDbContext.SaveChanges();
            return true;
        }
        catch (Exception exception)
        {
            return false;
        } 
    }

    public bool Update(int id, University universityData)
    {
        try
        {
            var university = _updateDbContext.Universities.Find(id);

            university.Name = universityData.Name;
            university.WebSite = universityData.WebSite;

            _updateDbContext.Universities.Update(university);
            _updateDbContext.SaveChanges();

            return true;
        }
        catch (Exception exception)
        {
            return false;
        }
    }

    public bool Delete(int id)
    {
        var university = _updateDbContext.Universities.Find(id);

        university.isActive = false;

        _updateDbContext.Universities.Update(university);
        _updateDbContext.SaveChanges();

        return true;
    }
    
}