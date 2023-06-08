using Infrastructure.Context;
using Infrastructure.Interfaces;
using Infrastructure.Model;

namespace Infrastructure;

public class ParticipationInfrastructure : IParticipationInfrastructure
{
    private readonly UpdateDbContext _updateDbContext;
    public ParticipationInfrastructure(UpdateDbContext updateDbContext)
    {
        _updateDbContext = updateDbContext;
    }

    public List<Participation> GetAll()
    {
        return _updateDbContext.Participations.Where(participation => participation.IsActive).ToList();
    }

    public Participation GetById(int id)
    {
        return _updateDbContext.Participations.Single(participation =>
            participation.IsActive && participation.Id == id);
    }

    public bool Create(Participation participationData)
    {
        try
        {
            participationData.IsActive = true;

            _updateDbContext.Participations.Add(participationData);
            _updateDbContext.SaveChanges();

            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }

    public bool Update(int id, Participation participationData)
    {
        try
        {
            var participation = _updateDbContext.Participations.Find(id);
            if (participation == null)
            {
                Console.WriteLine("Participation doesn't exist");
                return false;
            }
            
            participation.ActivityId = participationData.ActivityId;

            _updateDbContext.Participations.Update(participation);
            _updateDbContext.SaveChanges();

            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }

    public bool Delete(int id)
    {
        var participation = _updateDbContext.Participations.Find(id);
        if (participation == null)
        {
            Console.WriteLine("Participation doesn't exist");
            return false;
        }

        participation.IsActive = false;

        _updateDbContext.Participations.Update(participation);
        _updateDbContext.SaveChanges();

        return true;
    }
}