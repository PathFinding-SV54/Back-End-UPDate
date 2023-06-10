using AutoMapper;
using Domain.Interfaces;
using Infrastructure.Model;
using Microsoft.AspNetCore.Mvc;
using update.Input;

namespace update.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UserController : ControllerBase
    {
        private readonly IUserDomain _userDomain;
        private readonly IMapper _mapper;

        public UserController(IUserDomain userDomain, IMapper mapper)
        {
            _userDomain = userDomain;
            _mapper = mapper;
        }

        [HttpGet]
        public List<User> Get()
        {
            return _userDomain.GetAll();
        }

        [HttpGet("{id}", Name = "GetUser")]
        public User Get(int id)
        {
            return _userDomain.GetById(id);
        }

        [HttpPost]
        public void Post([FromBody] UserData userData)
        {
            var user = _mapper.Map<UserData, User>(userData);
            _userDomain.Create(user);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] UserData userData)
        {
            var user = _mapper.Map<UserData, User>(userData);
            _userDomain.Update(id, user);
        }

        [HttpDelete("{id}")]

        public void Delete(int id)
        {
            _userDomain.Delete(id);
        }
    }
}