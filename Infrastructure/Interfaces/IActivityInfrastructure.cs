using Infrastructure.Model;

namespace Infrastructure.Interfaces;


public interface IActivityInfrastructure
{
    List<Activity> GetAll();
    public Activity GetById(int id);
    bool Create(Activity activityData); 
    bool Update(int id, Activity activityData );
    bool Delete(int id);
    
}