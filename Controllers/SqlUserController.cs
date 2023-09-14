using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Factory_Server.Contexts;
using Factory_Server.Models;

namespace Factory_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SqlUserController : ControllerBase
    {
        private readonly UserSqlContext _context;

        public SqlUserController(UserSqlContext context)
        {
            _context = context;
        }


        // GET: api/SqlUser
        [HttpGet]
        [Route("getAllUsers")]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        {
          if (_context.Users == null)
          {
              return NotFound();
          }
            return await _context.Users.ToListAsync();
        }
     

        // POST: api/SqlUser
        [HttpPost]
        [Route("addUser")]
        public async Task<ActionResult<User>> AddUser(User user)
        {
          if (_context.Users == null)
          {
              return Problem("Entity set 'UserSqlContext.Users'  is null.");
          }
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        private bool UserExists(int id)
        {
            return (_context.Users?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
