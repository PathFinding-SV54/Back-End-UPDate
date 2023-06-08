using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Infrastructure;
using Infrastructure.DataClass;
using Infrastructure.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace update
{
    [Route("api/[controller]")]
    [ApiController]
    public class UniversityController : ControllerBase
    {
        //Inyeccion
        private IUniversityInfrastructure _universityInfrastructure;
        private IUniversityDomain _universityDomain;

        public UniversityController(IUniversityInfrastructure universityInfrastructure, IUniversityDomain universityDomain)
        {
            _universityInfrastructure = universityInfrastructure;
            _universityDomain = universityDomain;
        }

        // GET: api/University
        [HttpGet]
        public List<University> Get()
        {
            //filter data
            //
            return _universityDomain.GetAll();
        }

        // GET: api/University/5
        [HttpGet("{id}", Name = "GetUniversity")]
        public University Get(int id)
        {
            return _universityDomain.GetById(id);
        }

        // POST: api/University
        [HttpPost]
        public void Post([FromBody] UniversityData university)
        {
            _universityDomain.Create(university);
        }

        // PUT: api/University/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] UniversityData university)
        {
            _universityDomain.Update(id, university);
        }

        // DELETE: api/University/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _universityDomain.Delete(id);
        }
    }
}