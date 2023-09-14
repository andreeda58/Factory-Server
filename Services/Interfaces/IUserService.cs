using Factory_Server.Models;

namespace Factory_Server.Services.Interfaces
{
    public interface IUserService
    {
        public Task AddUser(User newUser);
      
        public Task<IEnumerable<User>> GetAllUsers();
    }
}
