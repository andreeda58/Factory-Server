using Factory_Server.Models;
using Factory_Server.Services.Interfaces;
using Microsoft.Data.SqlClient;
using Oracle.ManagedDataAccess.Client;
using System.Data;

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

        public void AddUser(User newUser)
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {

                OracleCommand command = new OracleCommand("Add_User_Procedure", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("id", OracleDbType.Int64).Value = newUser.Id;
                command.Parameters.Add("name", OracleDbType.Varchar2).Value = newUser.Name;
                command.Parameters.Add("lastName", OracleDbType.Varchar2).Value = newUser.LastName;
                command.Parameters.Add("age", OracleDbType.Int64).Value = newUser.Age;
                command.Parameters.Add("job", OracleDbType.Varchar2).Value = newUser.Job;

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<User> GetAllUsers()
        {
            List<User> UserDetails = new List<User>();

            // Create a connection object
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                connection.Open();
                OracleCommand command = new OracleCommand("SELECT * FROM [Users]", connection);
                using (OracleDataReader dataReader = command.ExecuteReader())
                {
                    // Go to the next result
                    while (dataReader.Read())
                    {
                        // Fetch the data from the current result
                        User user = new User
                        {
                            Id = (int)dataReader["id"],
                            Name = (string)dataReader["name"],
                            LastName = (string)dataReader["lastName"],
                            Age = (int)dataReader["aage"],
                            Job = (string)dataReader["job"]
                        };
                        UserDetails.Add(user);
                    }
                }
            }
            return UserDetails;
        }
    }
}
