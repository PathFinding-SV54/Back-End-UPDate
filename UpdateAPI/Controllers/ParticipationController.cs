using Domain;
using Infrastructure;
using Infrastructure.DataClass;
using Infrastructure.Model;
using Microsoft.AspNetCore.Mvc;

namespace update;

[Route("api/[controller]")]
[ApiController]
public class ParticipationController : ControllerBase
{
    private IParticipationInfrastructure _participationInfrastructure;
    private IParticipationDomain _participationDomain;


    public ParticipationController(IParticipationInfrastructure participationInfrastructure,
        IParticipationDomain participationDomain)
    {
        _participationInfrastructure = participationInfrastructure;
        _participationDomain = participationDomain;
    }

    //GET : api/Participation
    [HttpGet]
    public List<Participation> Get()
    {
        return _participationDomain.GetAll();
    }

    //GET : api/Participation/1
    [HttpGet("{id}", Name = "GetParticipation")]
    public Participation Get(int id)
    {
        return _participationDomain.GetById(id);
    }

    [HttpPost]
    public void Post([FromBody] ParticipationData participationData)
    {
        _participationDomain.Create(participationData);
    }

    [HttpPut("{id}")]
    public void Put(int id, [FromBody] ParticipationData participationData)
    {
        _participationDomain.Update(id, participationData);
    }

    [HttpDelete("{id}")]
    public void Delete(int id)
    {
        _participationDomain.Delete(id);
    }
}