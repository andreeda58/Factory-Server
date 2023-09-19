using Factory_Server.Contexts;
using Factory_Server.Models;
using Factory_Server.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Factory_Server.Services
{
    public class SqlUserService:IUserService
    {
        private readonly UserSqlContext _userSqlContetx;

        public SqlUserService(UserSqlContext userSqlContetx)
        {
            _userSqlContetx = userSqlContetx;
        }


        public async Task AddUser(User newUser)
        {
            _userSqlContetx.Users.Add(newUser);
           await _userSqlContetx.SaveChangesAsync();
        }



        public async Task<IEnumerable<User>> GetAllUsers()
        {
            var users = await _userSqlContetx.Users.ToListAsync();
            return users;
        }
    }
}
