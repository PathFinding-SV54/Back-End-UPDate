using Infrastructure.Context;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Model;

public class UserInfraestructure: IUserInfraestructure
{
    private UpdateDbContext _updateDbContext;

    public UserInfraestructure(UpdateDbContext updateDbContext)
    {
        _updateDbContext = updateDbContext;
    }

    public async Task<User> GetByUsername(string username)
    {
        return await _updateDbContext.Users.SingleAsync(u => u.Username == username);
    }

    public async Task<int> Signup(User user)
    {
        user.DateCreated=DateTime.Now;
        _updateDbContext.Users.Add(user);
        await _updateDbContext.SaveChangesAsync();
        return user.Id;
    }

}