using Infrastructure.Context;
using Infrastructure.DataClass;
using Infrastructure.Model;
using System.Collections.Generic;
using System;

namespace Infrastructure;

public class UniversityInfrastructure : IUniversityInfrastructure
{
    private UpdateDbContext _updateDbContext;

    public UniversityInfrastructure(UpdateDbContext updateDbContext)
    {
        _updateDbContext = updateDbContext;
    }

    public List<University> GetAll()
    {
        return _updateDbContext.Universities.ToList();
    }
    public University GetById(int id)
    {
        return _updateDbContext.Universities.Single(university.Id == id);
    }
    public bool Create(UniversityData universityData)
    {
        try
        {
            University university = new University();
            university.Name = universityData.Name;
            university.WebSite = universityData.WebSite;
            university.IsActive = true;

            _updateDbContext.Universities.Add(university);
            _updateDbContext.SaveChanges();
            return true;
        }
        catch (Exception exception)
        {
            return false;
        }
    }

    public bool Update(int id, UniversityData universityData)
    {
        try
        {
            var university = _updateDbContext.Universities.Find(id); //obtengo

            university.Name = UniversityData.Name;
            university.WebSite = UniversityData.WebSite;

            _updateDbContext.Universities.Update(university); //modifco


            _updateDbContext.SaveChanges();

            return true;
        }
        catch (Exception ex)
        {
            return false;
        }

    }

    public bool Delete(int id)
    {
        var university = _updateDbContext.Universities.Find(id); //obtengo

        university.IsActive = false;

        _updateDbContext.Universities.Update(university); //modifco

        _updateDbContext.SaveChanges();

        return true;
    }

}