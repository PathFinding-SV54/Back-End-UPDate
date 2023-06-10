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
    
    
    
}