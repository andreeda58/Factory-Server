using Factory_Server.Contexts;
using Factory_Server.Models;
using Factory_Server.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Factory_Server.Services
{
    public class SqlUserService:IUserService
    {
        private readonly UserSqlContext _userSqlContext;

        public SqlUserService(UserSqlContext userSqlContetx)
        {
            _userSqlContext = userSqlContetx;
        }


        public async Task AddUserAsync(User newUser)
        {
            _userSqlContext.Users.Add(newUser);
           await _userSqlContext.SaveChangesAsync();
        }



        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            var users = await _userSqlContext.Users.ToListAsync();
            return users;
        }
    }
}
