using Infrastructure.Model;

namespace Domain.Interfaces;

public interface IActivityDomain
{
    List<Activity> GetAll();
    public Activity GetById(int id);
    bool Create(Activity activityData); 
    bool Update(int id, Activity activityData );
    bool Delete(int id);
}