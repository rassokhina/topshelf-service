using System.Data.Entity;
using ServiceCore.Entities;

namespace ServiceCore.Context
{
    public class UserContext : DbContext, IUserContext 
    {
        public UserContext(): this("name=UserContext")
        {
        }

        public UserContext(string connectionString) : base(connectionString)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserConfiguration());
        }

        public virtual DbSet<User> Users { get; set; }
    }
}
