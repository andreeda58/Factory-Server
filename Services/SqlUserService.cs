using Factory_Server.Contexts;
using Factory_Server.Models;
using Factory_Server.Services.Interfaces;

namespace Factory_Server.Services
{
    public class SqlUserService:IUserService
    {
        private readonly UserSqlContext _userSqlContetx;

        public SqlUserService(UserSqlContext userSqlContetx)
        {
            _userSqlContetx = userSqlContetx;
        }

        public User AddUser(User newUser)
        {
            _userSqlContetx.Users.Add(newUser);
            _userSqlContetx.SaveChanges();

            return newUser;
        }

        public IEnumerable<User> GetAllUsers()
        {
           return _userSqlContetx.Users;
        }

       
    }
}
