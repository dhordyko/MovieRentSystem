using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;

namespace MovieRent.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public int RegisterViewModeld { get; set; }
        
        public DateTime? BirthDate { get; set; }
        public byte MembershipTypeId { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
    
        public string Address { get; set; }
        public int Phone { get; set; }
        public string CssTheme
        { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {    
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {        public DbSet<Customer>Customers { get; set; }
         public DbSet<Movie> Movies { get; set; }
        public DbSet<Country> Countries { get; set; }
         public DbSet<MembershipType> MembershipType { get; set; }
      
        public DbSet<GenreType> GenreTypes { get; set; }

        public DbSet<Orders> Orders { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}