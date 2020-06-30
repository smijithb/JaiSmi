using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using AspNet.Identity.SQLite;
using System.Security.Principal;
using System;

namespace JaiSmi.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        #region Private Variables

        private string fullName;

        #endregion

        #region Properties

        public string FullName
        {
            get { return fullName; }
            set
            {
                fullName = value;
                string[] nameComponents = fullName.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var name in nameComponents)
                {
                    if (!string.IsNullOrWhiteSpace(name))
                    {
                        Initials += name.Substring(0,1);
                    }
                }
            }
        }

        public string Initials { get; set; }

        #endregion

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            manager.ClaimsIdentityFactory = new ApplicationClaimsIdentityFactory() { FullName = this.FullName, Initials = this.Initials };

            if (!string.IsNullOrWhiteSpace(this.FullName))
                userIdentity.AddClaim(new Claim("FullName", this.FullName.ToString()));

            if (!string.IsNullOrWhiteSpace(this.Initials))
                userIdentity.AddClaim(new Claim("Initials", this.Initials.ToString()));
            
            return userIdentity;
        }
    }

    public class ApplicationDbContext : SQLiteDatabase //IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection") //base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }

    public static class IdentityExtensions
    {
        public static string GetFullName(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("FullName");
            // Test for null to avoid issues during local testing
            return (claim != null) ? claim.Value : string.Empty;
        }

        public static string GetInitials(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("Initials");
            // Test for null to avoid issues during local testing
            return (claim != null) ? claim.Value : string.Empty;
        }
    }

    public class ApplicationClaimsIdentityFactory : ClaimsIdentityFactory<ApplicationUser>
    {
        public string FullName { get; set; }
        public string Initials { get; set; }
        public async override Task<ClaimsIdentity> CreateAsync(
                UserManager<ApplicationUser, string> manager,
                ApplicationUser user,
                string authenticationType)
        {
            var identity = await base.CreateAsync(manager, user, authenticationType);
            
            if (!string.IsNullOrWhiteSpace(this.FullName))
                identity.AddClaim(new Claim("FullName", FullName));
            if (!string.IsNullOrWhiteSpace(this.Initials))
                identity.AddClaim(new Claim("Initials", Initials));

            return identity;
        }
    }
}