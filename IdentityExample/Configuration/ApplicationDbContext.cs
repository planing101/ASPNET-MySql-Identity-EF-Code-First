using IdentityExample.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace IdentityExample.Configuration
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        static ApplicationDbContext()
        {
            Database.SetInitializer(new MySqlInitializer());
        }

        public ApplicationDbContext()
            : base("LocalMySqlServer", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            #region Identity Mapping

            modelBuilder.Entity<ApplicationUser>().Property(p => p.UserName)
                .HasColumnType("varchar")
                .HasMaxLength(100);

            modelBuilder.Entity<IdentityRole>().Property(p => p.Name)
                .HasColumnType("varchar")
                .HasMaxLength(200);

            base.OnModelCreating(modelBuilder);

            #endregion

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}