using HCMS.API.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace HCMS.API.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    //public class ApplicationUser : IdentityUser
    //{
    //    public virtual UserInfo UserInfo { get; set; }

    //    public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
    //    {
    //        // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
    //        var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
    //        // Add custom user claims here
    //        return userIdentity;
    //    }
    //}
    

    //public class AuthContext : IdentityDbContext<ApplicationUser>
    //{
    //    public AuthContext()
    //        : base("AuthContext", throwIfV1Schema: false)
    //    {
    //        Configuration.ProxyCreationEnabled = false;
    //        Configuration.LazyLoadingEnabled = false;
    //    }

    //    public static AuthContext Create()
    //    {
    //        return new AuthContext();
    //    }
    //    public DbSet<Client> Clients { get; set; }
    //    public DbSet<RefreshToken> RefreshTokens { get; set; }
    //    public DbSet<UserInfo> UserInfo { get; set; }
    //}

    public enum ApplicationTypes
    {
        JavaScript = 0,
        NativeConfidential = 1
    };
    
}