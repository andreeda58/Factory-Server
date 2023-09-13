using Factory_Server.Models;
using Microsoft.EntityFrameworkCore;

namespace Factory_Server.Contexts
{
    public class UserSqlContext:DbContext
    {
        public UserSqlContext(DbContextOptions options) : base(options)
        {

        }
        public virtual DbSet<User> Users { get; set; }
    }
}
