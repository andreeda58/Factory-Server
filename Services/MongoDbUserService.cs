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

        public bool AddUser(User newUser)
        {
            try
            {
                if (newUser != null)
                {
                    _userTable.InsertOne(newUser);
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
           

        }

        public IEnumerable<User> GetAllUsers()
        {
            return _userTable.Find(FilterDefinition<User>.Empty).ToList();
        }

        public async Task<IEnumerable<User>>GetAllUsersAsync()
        {
            return await Task.Run(GetAllUsers);
        }

        public async Task<bool> AddUserAsync(User newUser)
        {
            return await Task.Run(()=>AddUser(newUser));
        }
    }
}
