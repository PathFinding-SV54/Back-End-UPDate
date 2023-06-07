using Infrastructure.DataClass;
using Infrastructure.Model;

namespace Domain;

public interface IActivityDomain
{
    List<Activity> GetAll();
    public Activity GetById(int id);
    bool Create(ActivityData activityData); 
    bool Update(int id, ActivityData activityData );
    bool Delete(int id);
}