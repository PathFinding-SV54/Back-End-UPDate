using Domain;
using Infrastructure;
using Infrastructure.DataClass;
using Infrastructure.Model;
using Microsoft.AspNetCore.Mvc;

namespace update;

[Route("api/[controller]")]
[ApiController]
public class CommunityController : ControllerBase
{
    private ICommunityInfrastructure _communityInfrastructure;
    private ICommunityDomain _communityDomain;

    public CommunityController(ICommunityInfrastructure communityInfrastructure, ICommunityDomain communityDomain)
    {
        _communityInfrastructure = communityInfrastructure;
        _communityDomain = communityDomain;
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
        _communityDomain.Create(communityData);
    }
    
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] CommunityData communityData)
    {
        _communityDomain.Update(id, communityData);
    }

    // DELETE: api/Community/1
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
        _communityDomain.Delete(id);
    }
}