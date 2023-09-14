using Factory_Server.Models;
using Factory_Server.Services.Interfaces;
using Microsoft.Data.SqlClient;

namespace Factory_Server.Services
{
    public class OracleUserService
    {
        private readonly IConfiguration _configuration;
        private string connectionString;

        public OracleUserService(IConfiguration configuration)
        {
            _configuration = configuration;
            if (_configuration.GetConnectionString("oracle") != null)
                connectionString = _configuration.GetConnectionString("oracle");
        }

        public User AddUser(User newUser)
        {
            return newUser;
        }

        public IEnumerable<User> GetAllUsers()
        {
            List<User> UserDetails = new List<User>();

            // Create a connection object
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM [Users]", connection);
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    // Go to the next result
                    while (dataReader.Read())
                    {
                        // Fetch the data from the current result
                        User user = new User
                        {
                            Id = (int)dataReader["id"],
                            Name = (string)dataReader["Name"],
                            LastName = (string)dataReader["LastName"],
                            Age = (int)dataReader["Quantity"],
                            Job = (string)dataReader["Job"]
                        };
                        UserDetails.Add(user);
                    }
                }
            }
            return UserDetails;
        }
    }
}
