using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace EverestVideoLibrary.Models
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

        public System.Data.Entity.DbSet<EverestVideoLibrary.Models.Artist> Artists { get; set; }

        public System.Data.Entity.DbSet<EverestVideoLibrary.Models.ArtistDVD> ArtistDVDs { get; set; }

        public System.Data.Entity.DbSet<EverestVideoLibrary.Models.DVDDetails> DVDDetails { get; set; }

        public System.Data.Entity.DbSet<EverestVideoLibrary.Models.MemberCategory> MemberCategories { get; set; }

        public System.Data.Entity.DbSet<EverestVideoLibrary.Models.Producer> Producers { get; set; }

        public System.Data.Entity.DbSet<EverestVideoLibrary.Models.Member> Members { get; set; }

        public System.Data.Entity.DbSet<EverestVideoLibrary.Models.Loan> Loans { get; set; }

        public System.Data.Entity.DbSet<EverestVideoLibrary.Models.ProducerDVD> ProducerDVDs { get; set; }
    }
}