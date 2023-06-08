using Domain.Interfaces;
using Infrastructure.Interfaces;
using Infrastructure.Model;

namespace Domain;

public class ActivityDomain: IActivityDomain
{
    private IActivityInfrastructure _activityInfrastructure;

    public ActivityDomain(IActivityInfrastructure activityInfrastructure)
    {
        _activityInfrastructure = activityInfrastructure;
    }

    public List<Activity> GetAll()
    {
        return _activityInfrastructure.GetAll();
    }

    public Activity GetById(int id)
    {
        return _activityInfrastructure.GetById(id);
    }

    public bool Create(Activity activityData)
    {
        return _activityInfrastructure.Create(activityData);
    }

    public bool Update(int id, Activity activityData)
    {
        return _activityInfrastructure.Update(id, activityData);
    }

    public bool Delete(int id)
    {
        return _activityInfrastructure.Delete(id);
    }
}