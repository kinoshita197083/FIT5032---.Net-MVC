using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Assignment_3rd_run.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Column> ColumnSet { get; set; }
        public DbSet<News> NewsSet { get; set; }

        public System.Data.Entity.DbSet<Assignment_3rd_run.Models.MembershipType> MembershipTypesSet { get; set; }


        public System.Data.Entity.DbSet<Assignment_3rd_run.Models.Membership> Memberships { get; set; }

        public System.Data.Entity.DbSet<Assignment_3rd_run.ViewModels.NewsColumnsViewModel> NewsColumnsViewModels { get; set; }

        public System.Data.Entity.DbSet<Assignment_3rd_run.Models.Tag> TagSet { get; set; }
        public System.Data.Entity.DbSet<Assignment_3rd_run.Models.SubNews> SubNewsSet { get; set; }
        public System.Data.Entity.DbSet<Assignment_3rd_run.Models.SubColumns> SubColumnsSet { get; set; }

        public System.Data.Entity.DbSet<Assignment_3rd_run.Models.Event> Events { get; set; }
    }
}