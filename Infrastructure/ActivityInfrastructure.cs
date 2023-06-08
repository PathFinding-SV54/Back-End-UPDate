using Infrastructure.Context;
using Infrastructure.Interfaces;
using Infrastructure.Model;

namespace Infrastructure;

public class ActivityInfrastructure : IActivityInfrastructure
{
    private readonly UpdateDbContext _updateDbContext;

    public ActivityInfrastructure(UpdateDbContext updateDbContext)
    {
        _updateDbContext = updateDbContext;
    }

    public List<Activity> GetAll()
    {
        return _updateDbContext.Activities.Where(activity => activity.IsActive).ToList();
    }
    public Activity GetById(int id)
    {
        return _updateDbContext.Activities.Single(activity => activity.IsActive && activity.Id == id);
    }
    public bool Create(Activity activityData)
    {
        try
        {
            activityData.IsActive = true;

            _updateDbContext.Activities.Add(activityData);
            _updateDbContext.SaveChanges();
            return true;
        }
        catch (Exception exception)
        {
            return false;
        }
    }

    public bool Update(int id, Activity activityData)
    {
        try
        {
            //using (var transaction = _updateDbContext.Database.BeginTransaction()){}
            var activity = _updateDbContext.Activities.Find(id); //obtengo

            activity.Title = activityData.Title;
            activity.Description = activityData.Description;
            activity.Address = activityData.Address;

            _updateDbContext.Activities.Update(activity); //modifco
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
        var activity = _updateDbContext.Activities.Find(id); //obtengo

        //_learningCenterDbContext.Tutorials.Remove(tutorial);

        activity.IsActive = false;
        
        _updateDbContext.Activities.Update(activity); //modifco
        
        _updateDbContext.SaveChanges();

        return true;
    }

}