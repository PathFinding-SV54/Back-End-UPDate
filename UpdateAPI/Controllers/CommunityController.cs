using AutoMapper;
using Domain.Interfaces;
using Infrastructure.Model;
using Microsoft.AspNetCore.Mvc;
using update.Input;

namespace update.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CommunityController : ControllerBase
{
    private readonly ICommunityDomain _communityDomain;
    private readonly IMapper _mapper;
    public CommunityController(ICommunityDomain communityDomain, IMapper mapper)
    {
        _communityDomain = communityDomain;
        _mapper = mapper;
    }
    
    //GET : api/Community
    [HttpGet]
    public List<Community> Get()
    {
        return _communityDomain.GetAll();
    }
    
    //GET : api/Community/1
    [HttpGet("{id}", Name = "GetCommunity")]
    public Community Get(int id)
    {
        return _communityDomain.GetById(id);
    }

    [HttpPost]
    public void Post([FromBody] CommunityData communityData)
    {
        var community = _mapper.Map<CommunityData, Community>(communityData);
        _communityDomain.Create(community);
    }
    
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] CommunityData communityData)
    {
        var community = _mapper.Map<CommunityData, Community>(communityData);
        _communityDomain.Update(id, community);
    }

    // DELETE: api/Community/1
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
        _communityDomain.Delete(id);
    }
}