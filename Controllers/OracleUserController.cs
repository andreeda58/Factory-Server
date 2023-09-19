using Factory_Server.Models;
using Factory_Server.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Factory_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OracleUserController : ControllerBase
    {
        private readonly OracleUserService _service;

        public OracleUserController(OracleUserService service)
        {
            _service = service;
        }
        // GET: api/<OracleUserController>
        [HttpGet]
        [Route("getAllUsers")]
        public async Task<IEnumerable<User>> Get()
        {
          return await _service.GetAllUsersAsync();
        }

        // POST api/<OracleUserController>
        [HttpPost]
        [Route("addUser")]
        public async Task Post(User newUser)
        {
          await  _service.AddUserAsync(newUser);
        }
       
    }
}
