namespace SteveComputerTraining.WebAPI.Migrations.ApplicationDbContext
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SteveComputerTraining.WebAPI.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\ApplicationDbContext";
        }

        protected override void Seed(SteveComputerTraining.WebAPI.Models.ApplicationDbContext context)
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
            var store = new UserStore<ApplicationUser>(context);
            var manager = new UserManager<ApplicationUser>(store);
            var hasher = new PasswordHasher();
            var user = new ApplicationUser
            {
                UserName = "smiazga",
                //Email = "steveo847@hotmail.com",
                PasswordHash = hasher.HashPassword("Pa$$w0rd"),
            };

            manager.Create(user, "Pa$$w0rd");
        }
    }
}
