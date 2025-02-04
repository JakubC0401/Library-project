using Library.Models;
using Library.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Library.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<UserModel> Get() => _userRepository.GetAllUsers();

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public UserModel Get(int id) => _userRepository.GetUser(id);
        
        // POST api/<UsersController>
        [HttpPost]
        public void Post([FromBody] UserModel value)
        {
            _userRepository.Add(value);
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] UserModel value)
        {
            _userRepository.Update(id, value);
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _userRepository.Delete(id);
        }
    }
}
