using ServiceCore.Entities;
using System.Data.Entity;

namespace ServiceCore.Context
{
    public interface IUserContext
    {
        DbSet<User> Users { get; set; }

        int SaveChanges();
    }
}
