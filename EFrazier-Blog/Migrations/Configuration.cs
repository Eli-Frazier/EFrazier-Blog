using EFrazier_Blog.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace EFrazier_Blog.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<EFrazier_Blog.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(EFrazier_Blog.Models.ApplicationDbContext context)
        {
            //create a few roles (admin and moderator)
            var roleManager = new RoleManager<IdentityRole>(
                new RoleStore<IdentityRole>(context));

            if(!context.Roles.Any(r => r.Name == "Admin"))
            {
                roleManager.Create(new IdentityRole { Name = "Admin" });
            }

            if (!context.Roles.Any(r => r.Name == "Moderator"))
            {
                roleManager.Create(new IdentityRole { Name = "Moderator" });
            }

            //create users (me and jason)
            var userManager = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));

            if (!context.Users.Any(u => u.Email == "eli_frazier@yahoo.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "eli_frazier@yahoo.com",
                    Email = "eli_frazier@yahoo.com",
                    FirstName = "Eli",
                    LastName = "Frazier",
                    DisplayName = "Eli-Frazier",
                }, "LavabombAdmin1");
            }

            if (!context.Users.Any(u => u.Email == "JasonTwichell@mailinator.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "JasonTwichell@mailinator.com",
                    Email = "JasonTwichell@mailinator.com",
                    FirstName = "Jason",
                    LastName = "Twichell",
                    DisplayName = "Jason",
                }, "Moderator1");
            }

            //Assign users to roles (me to admin, jason to mod)
            var adminId = userManager.FindByEmail("eli_frazier@yahoo.com").Id;
            userManager.AddToRole(adminId, "Admin");

            var moderatorId = userManager.FindByEmail("JasonTwichell@mailinator.com").Id;
            userManager.AddToRole(moderatorId, "Moderator");
        }
    }
}
