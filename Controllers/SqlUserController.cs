using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Factory_Server.Contexts;
using Factory_Server.Models;
using Factory_Server.Services.Interfaces;

namespace Factory_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SqlUserController : ControllerBase
    {
        
        private readonly IUserService _userSqlService;

        public SqlUserController(IUserService userSqlService)=>_userSqlService = userSqlService;


        // GET: api/SqlUser
        [HttpGet]
        [Route("getAllUsers")]
        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _userSqlService.GetAllUsersAsync();
        }
     

        // POST: api/SqlUser
        [HttpPost]
        [Route("addUser")]
        public async Task AddUser(User user)
        {
           await  _userSqlService.AddUserAsync(user);
        }

     
    }
}
