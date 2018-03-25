using ServiceCore.Context;
using System.Data.Entity.Migrations;

namespace ServiceCore.Migrations
{
    internal class MigrationConfiguration : DbMigrationsConfiguration<UserContext>
    {
        public MigrationConfiguration()
        {
            AutomaticMigrationsEnabled = false;
        }
    }
}
