using Factory_Server.Models;

namespace Factory_Server.Services.Interfaces
{
    public interface IUserService
    {
        public User AddUser(User newUser);
      
        public IEnumerable<User> GetAllUsers();
    }
}
