using Factory_Server.Models;
using Factory_Server.Services;
using Factory_Server.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Factory_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MongoUserController : ControllerBase
    {
        private readonly MongoDbUserService _mongodbService;

        public MongoUserController(MongoDbUserService mongodbService)
        {
            _mongodbService = mongodbService;
        }

        // GET: api/<MongoUserController>
        [HttpGet]
        [Route("getAllUsers")]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        {
           return _mongodbService.GetAllUsers().ToList();
        }
     

        // POST api/<MongoUserController>
        [HttpPost]
        [Route("addUser")]
        public  User AddUser( User user)
        {
           return _mongodbService.AddUser(user);
        }
      
    }
}
