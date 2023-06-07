using System.Runtime.InteropServices.JavaScript;
using Infrastructure;
using Infrastructure.DataClass;
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

    public bool Create(ActivityData activityData)
    {
        return _activityInfrastructure.Create(activityData);
    }

    public bool Update(int id, ActivityData activityData)
    {
        return _activityInfrastructure.Update(id, activityData);
    }

    public bool Delete(int id)
    {
        return _activityInfrastructure.Delete(id);
    }
}