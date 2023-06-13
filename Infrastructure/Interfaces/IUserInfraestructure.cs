using Infrastructure.Model;

namespace Infrastructure.Interfaces;

public interface IUserInfraestructure
{
    Task<User> GetByUsername(string username);
    Task<int> Signup(User user);
}