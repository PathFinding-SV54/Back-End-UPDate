using Domain.Interfaces;
using Infrastructure.Interfaces;
using Infrastructure.Model;

namespace Domain;

public class UserDomain : IUserDomain
{
    private IUserInfrastructure _userInfrastructure;

    public UserDomain(IUserInfrastructure userInfrastructure)
    {
        _userInfrastructure = userInfrastructure;
    }

    public List<User> GetAll()
    {
        return _userInfrastructure.GetAll();
    }

    public User GetById(int id)
    {
        return _userInfrastructure.GetById(id);
    }

    public bool Create(User userData)
    {
        return _userInfrastructure.Create(userData);
    }
    
    public bool Update(int id, User userData)
    {
        return _userInfrastructure.Update(id, userData);
    }

    public bool Delete(int id)
    {
        return _userInfrastructure.Delete(id);
    }
}