using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Factory_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OracleUserController : ControllerBase
    {
        // GET: api/<OracleUserController>
        [HttpGet]
        [Route("getAllUsers")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // POST api/<OracleUserController>
        [HttpPost]
        [Route("addUser")]
        public void Post([FromBody] string value)
        {
        }
       
    }
}
