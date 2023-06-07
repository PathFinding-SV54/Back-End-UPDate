using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Infraestructure;
using Infraestructure.DataClass;
using Infrastructure.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace update
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        //Inyeccion
        private IActivityInfraestructure _activityInfraestructure;
        private IActivityDomain _activityDomain;

        public ActivityController(IActivityInfraestructure activityInfraestructure, IActivityDomain activityDomain)
        {
            _activityInfraestructure = activityInfraestructure;
            _activityDomain = activityDomain;
        }
        
        // GET: api/Activity
        [HttpGet]
        public List<Activity> Get()
        {
            //filter data
            //
            return _activityDomain.GetAll();
        }

        // GET: api/Activity/5
        [HttpGet("{id}", Name = "Get")]
        public Activity Get(int id)
        {
            return _activityDomain.GetById(id);
        }

        // POST: api/Activity
        [HttpPost]
        public void Post([FromBody] ActivityData activity)
        {
            /*if (ModelState.IsValid) //valida las condiciones del model 
            {
                Tutorial tutorial  = new Tutorial(){
                Title= activity.Title
                Description= activity.Description
                Address= activity.Address
                Date= activity.Date
                }
            }
            else
            {
                StatusCode(400);
            }*/
            _activityDomain.Create(activity);
        }

        // PUT: api/Activity/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ActivityData activity)
        {
            _activityDomain.Update(id,activity);
        }

        // DELETE: api/Activity/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _activityDomain.Delete(id);
        }
    }
}
