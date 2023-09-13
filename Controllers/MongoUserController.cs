using Factory_Server.Models;
using Factory_Server.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Factory_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MongoUserController : ControllerBase
    {
        private readonly IUserMongoDbService _mongodbService;

        public MongoUserController(IUserMongoDbService mongodbService)
        {
            _mongodbService = mongodbService;
        }

        // GET: api/<MongoUserController>
        [HttpGet]
        [Route("getAllUsers")]
        public IEnumerable<User> Get()
        {
           return _mongodbService.GetAllUsers();
        }
     

        // POST api/<MongoUserController>
        [HttpPost]
        [Route("addUser")]
        public void Post()
        {
            User newUser = new User() { Id = 1, Age = 25, Name = "andree", LastName = "del aguila", Job = "programer" };
            _mongodbService.AddUser(newUser);
        }
      
    }
}
