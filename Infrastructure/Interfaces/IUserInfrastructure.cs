using Infrastructure.Model;

namespace Infrastructure.Interfaces;

public interface IUserInfrastructure
{
    List<User> GetAll();

    public User GetById(int id);

    bool Create(User userData);

    bool Update(int id, User userData);

    bool Delete(int id);
}