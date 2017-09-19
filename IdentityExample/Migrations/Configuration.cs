using IdentityExample.Configuration;
using System.Data.Entity.Migrations;

namespace IdentityExample.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;

            SetSqlGenerator("MySql.Data.MySqlClient", new MySql.Data.Entity.MySqlMigrationSqlGenerator());

            CodeGenerator = new MySql.Data.Entity.MySqlMigrationCodeGenerator();
        }

        protected override void Seed(ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );

            // Add default user roles
            context.Database.ExecuteSqlCommand("INSERT INTO `test`.`aspnetroles` (`Id`, `Name`) VALUES (1, 'Admin')");
            context.Database.ExecuteSqlCommand("INSERT INTO `test`.`aspnetroles` (`Id`, `Name`) VALUES (2, 'Guest')");
        }
    }
}
