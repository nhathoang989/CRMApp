namespace HCMS.API.Migrations
{
    using Infrastructure;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<HCMS.API.Infrastructure.AuthContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(HCMS.API.Infrastructure.AuthContext context)
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
            //

            //var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new AuthContext()));
            //var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new AuthContext()));
            //Entities.UserInfo infos = new Entities.UserInfo();
            //infos.FirstName = "Hoang";
            //infos.LastName = "Nguyen";
            //infos.Address = "";
            //infos.UserName = "tintintin89";
            //var user = new ApplicationUser()
            //{
            //    UserName = "tintintin89",
            //    Email = "nhathoang989@gmail.com",
            //    EmailConfirmed = true,
            //    FirstName = "Hoang",
            //    LastName = "Nguyen",
            //    Level = 1,
            //    JoinDate = DateTime.Now.AddYears(-1),
            //    UserInfo = infos
            //};

            //if (manager.FindByEmail(user.Email) == null)
            //{
            //    manager.Create(user, "1234qwe@");

            //    manager.Create(user, "MySuperP@ss!");

            //}
            //else {

            //}
            

            //if (roleManager.Roles.Count() == 0)
            //{
            //    roleManager.Create(new IdentityRole { Name = "SuperAdmin" });
            //    roleManager.Create(new IdentityRole { Name = "Admin" });
            //    roleManager.Create(new IdentityRole { Name = "User" });
            //}

            //var adminUser = manager.FindByName("tintintin89");

            //manager.AddToRoles(adminUser.Id, new string[] { "SuperAdmin", "Admin" });
        }
    }
}
