namespace Work.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Work.Model.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Work.Data.WorkDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Work.Data.WorkDbContext context)
        {
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new WorkDbContext()));
            var roleManager = new RoleManager<ApplicationRole>(new RoleStore<ApplicationRole>(new WorkDbContext()));
            var user = new ApplicationUser()
            {
                UserName = "longdo",
                Email = "dohuuhailong@gmail.com",
                EmailConfirmed = true,
                birthday = DateTime.Now,
                name = "Đỗ Hữu Hải Long",
                status = true,
            };

            manager.Create(user, "123654$");
            if (!roleManager.Roles.Any())
            {
                roleManager.Create(new ApplicationRole { Name = "Admin" });
                roleManager.Create(new ApplicationRole { Name = "AppManager" });
                roleManager.Create(new ApplicationRole { Name = "CompanyAdmin" });
                roleManager.Create(new ApplicationRole { Name = "JobFinder" });
                roleManager.Create(new ApplicationRole { Name = "CompanyEmployee" });
            }

            var adminUser = manager.FindByEmail("dohuuhailong@gmail.com");
            manager.AddToRoles(adminUser.Id, new string[] { "Admin", "AppManager" });
        }
    }
}