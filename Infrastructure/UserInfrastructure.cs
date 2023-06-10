using Infrastructure.Context;
using Infrastructure.Model;
using Infrastructure.Interfaces;

namespace Infrastructure;

public class UserInfrastructure : IUserInfrastructure
{
    private readonly UpdateDbContext _updateDbContext;

    public UserInfrastructure(UpdateDbContext updateDbContext)
    {
        _updateDbContext = updateDbContext;
    }

    public List<User> GetAll()
    {
        return _updateDbContext.Users.Where(user => user.IsActive).ToList();
    }

    public User GetById(int id)
    {
        return _updateDbContext.Users.Single(user => user.IsActive && user.Id == id);
    }

    public bool Create(User userData)
    {
        try
        {
            userData.IsActive = true;

            _updateDbContext.Users.Add(userData);
            _updateDbContext.SaveChanges();
            return true;
        }
        catch (Exception exception)
        {
            return false;
        }
    }

    public bool Update(int id, User userData)
    {
        try
        {
            var user = _updateDbContext.Users.Find(id);

            user.Username = userData.Username;
            user.Password = userData.Password;
            user.Email = userData.Email;
            user.Bio = userData.Bio;
            user.ApellidoMaterno = userData.ApellidoMaterno;
            user.ApellidoPaterno = userData.ApellidoPaterno;

            _updateDbContext.Users.Update(user);
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
        var user = _updateDbContext.Users.Find(id);

        user.IsActive = false;
        _updateDbContext.Users.Update(user);
        _updateDbContext.SaveChanges();
        return true;
    }


}