using System.Runtime.InteropServices.JavaScript;
using Infrastructure;
using Infrastructure.DataClass;
using Infrastructure.Model;

namespace Domain;

public class ActivityDomain: IActivityDomain
{
    private IActivityInfraestructure _activityInfraestructure;

    public ActivityDomain(IActivityInfraestructure activityInfraestructure)
    {
        _activityInfraestructure = activityInfraestructure;
    }

    public List<Activity> GetAll()
    {
        return _activityInfraestructure.GetAll();
    }

    public Activity GetById(int id)
    {
        return _activityInfraestructure.GetById(id);
    }

    public bool Create(ActivityData activityData)
    {
        return _activityInfraestructure.Create(activityData);
    }

    public bool Update(int id, ActivityData activityData)
    {
        return _activityInfraestructure.Update(id, activityData);
    }

    public bool Delete(int id)
    {
        return _activityInfraestructure.Delete(id);
    }
}