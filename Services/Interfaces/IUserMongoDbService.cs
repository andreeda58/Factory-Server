using Factory_Server.Models;

namespace Factory_Server.Services.Interfaces
{
    public interface IUserMongoDbService
    {

        public User AddUser(User newUser);

        public IEnumerable<User> GetAllUsers();
    }
}
