using Factory_Server.Models;
using Factory_Server.Services.Interfaces;
using MongoDB.Driver;


namespace Factory_Server.Services
{
    public class MongoDbUserService : IUserMongoDbService
    {
        private readonly IConfiguration _configuration;
        private MongoClient _mongoClient = null;
        private IMongoDatabase _mongoDatabase = null;
        private IMongoCollection<User> _userTable = null;


        public MongoDbUserService(IConfiguration configuration)
        {

            _configuration = configuration;
            _mongoClient = new MongoClient(_configuration.GetConnectionString("MongoDb"));
            _mongoDatabase = _mongoClient.GetDatabase("FactoryDb");
            _userTable = _mongoDatabase.GetCollection<User>("User");
            
        }

        public User AddUser(User newUser)
        {
            if(newUser != null)
            {
                _userTable.InsertOne(newUser);
            }

            return newUser;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _userTable.Find(FilterDefinition<User>.Empty).ToList();
        }
    }
}
