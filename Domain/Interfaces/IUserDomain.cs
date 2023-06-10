using Infrastructure.Model;
namespace Domain.Interfaces;

public interface IUserDomain
{
    List<User> GetAll();

    public User GetById(int id);

    public bool Create(User userData);
    
    public bool Update(int id, User userData);

    public bool Delete(int id);
}