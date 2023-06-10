using AutoMapper;
using Domain.Interfaces;
using Infrastructure.Model;
using Microsoft.AspNetCore.Mvc;
using update.Input;

namespace update.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UniversityController : ControllerBase
    {
        private readonly IUniversityDomain _universityDomain;
        private readonly IMapper _mapper;

        public UniversityController(IUniversityDomain universityDomain, IMapper mapper)
        {
            _universityDomain = universityDomain;
            _mapper = mapper;
        }

        [HttpGet]
        public List<University> Get()
        {
            return _universityDomain.GetAll();
        }

        [HttpGet("{id}", Name = "GetUniversity")]
        public University Get(int id)
        {
            return _universityDomain.GetById(id);
        }

        [HttpPost]
        public void Post([FromBody] UniversityData universityData)
        {
            var university = _mapper.Map<UniversityData, University>(universityData);
            _universityDomain.Create(university);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] UniversityData universityData)
        {
            var university = _mapper.Map<UniversityData, University>(universityData);
            _universityDomain.Update(id, university);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _universityDomain.Delete(id);
        }

    }
    
}
