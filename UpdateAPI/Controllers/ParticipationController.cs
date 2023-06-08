using AutoMapper;
using Domain.Interfaces;
using Infrastructure.Model;
using Microsoft.AspNetCore.Mvc;
using update.Input;

namespace update.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ParticipationController : ControllerBase
{
    private readonly IParticipationDomain _participationDomain;
    private readonly IMapper _mapper;

    public ParticipationController(IParticipationDomain participationDomain, IMapper mapper)
    {
        _participationDomain = participationDomain;
        _mapper = mapper;
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
        var participation = _mapper.Map<ParticipationData, Participation>(participationData);
        _participationDomain.Create(participation);
    }

    [HttpPut("{id}")]
    public void Put(int id, [FromBody] ParticipationData participationData)
    {
        var participation = _mapper.Map<ParticipationData, Participation>(participationData);
        _participationDomain.Update(id, participation);
    }

    [HttpDelete("{id}")]
    public void Delete(int id)
    {
        _participationDomain.Delete(id);
    }
}