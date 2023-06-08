using AutoMapper;
using Domain.Interfaces;
using Infrastructure.Model;
using Microsoft.AspNetCore.Mvc;
using update.Input;

namespace update.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        //Inyeccion
        private readonly IActivityDomain _activityDomain;
        private readonly IMapper _mapper;

        public ActivityController(IActivityDomain activityDomain, IMapper mapper)
        {
            _activityDomain = activityDomain;
            _mapper = mapper;
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
        [HttpGet("{id}", Name = "GetActivity")]
        public Activity Get(int id)
        {
            return _activityDomain.GetById(id);
        }

        // POST: api/Activity
        [HttpPost]
        public void Post([FromBody] ActivityData activityData)
        {
            var activity = _mapper.Map<ActivityData, Activity>(activityData);
            _activityDomain.Create(activity);
        }

        // PUT: api/Activity/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ActivityData activityData)
        {
            var activity = _mapper.Map<ActivityData, Activity>(activityData);
            _activityDomain.Update(id, activity);
        }

        // DELETE: api/Activity/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _activityDomain.Delete(id);
        }
    }
}
