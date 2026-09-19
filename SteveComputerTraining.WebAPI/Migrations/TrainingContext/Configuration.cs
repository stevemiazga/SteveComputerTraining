namespace SteveComputerTraining.WebAPI.Migrations.TrainingContext
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SteveComputerTraining.WebAPI.Models.TrainingContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\TrainingContext";
        }

        protected override void Seed(SteveComputerTraining.WebAPI.Models.TrainingContext context)
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
            var users = new List<User>
            {
                new User { UserName = "smiazga" }
            };

            users.ForEach(s => context.Users.AddOrUpdate(p => p.UserName, s));
            context.SaveChanges();

            var courses = new List<Course>
            {
               new Course { Category ="Web Development", Title="Programming in HTML5 with JavaScript and CSS3", Description = "This course provides an introduction to HTML5, CSS3, and JavaScript. The course focuses on using HTML5/CSS3/JavaScript to implement programming logic, define and use variables, perform looping and branching, develop user interfaces, capture and validate user input, store data, and create well-structured application." },
               new Course { Category ="Web Development", Title="Programming in C#", Description = "This course teaches developers the programming skills that are required to create applications using the C# language.  The course focuses on the core syntax and features of C# in the .NET Framework, creating classes and call methods, handling exceptions, and various other features to ensure a proficient C# application." },
               new Course { Category ="Web Development", Title="Developing ASP.NET MVC 4 Web Applications", Description = "This course covers development of ASP.NET MVC applications using .NET Framework tools and technologies. The course focuses on creating MVC Models and writing code that implements business logic within Model methods, properties, and events. Also covers adding Controllers to an MVC Application to manage user interaction, update models, and select and return views, and creating Views in an MVC application that display and edit data and interact with Models and Controllers." },
               new Course { Category ="Web Development", Title="Developing Windows Azure and Web Services", Description = "This course covers using Microsoft Technology to design and develop services that access local and remote data from various data sources, and how to develop and deploy services to hybrid environments, including on-premises servers and Windows Azure. The Microsoft Technologies that will be explored are Entity Framework, ASP.NET Web API, Windows Communication	Foundation (WCF), and Windows Azure for web development." },
               new Course { Category ="Database Development", Title="Microsoft SQL Server Database Development", Description = "This course covers the technical skills required to develop Microsoft SQL Server databases. The course focuses on creating tables, views, and indexes, stored procedures, and using Transact-SQL for querying the database." },
               new Course { Category ="Database Development", Title="Implementing and Maintaining Microsoft SQL Server Reporting Services", Description = "This course covers how to use Microsoft Reporting Services development tools to create reports, and how to use the Reporting Services management and administrative tools to manage a Reporting Services solution. This course focuses on creating a reporting services report, creating and manipulate data sets for reporting services report, and configuration and adminstration of all Reporting Services reports through Report Manager." },
               new Course { Category ="Database Development", Title="Implementing and Maintaining Microsoft SQL Server Integration Services", Description = "This course covers how to develop, deploy, and manage Microsoft Integration Services packages. The course focues on using integration services packages to perform ETL processes which implement data transfer or extract, transform, and load data." },
               new Course { Category ="Database Development", Title="Implementing and Maintaining Microsoft SQL Server Analysis Services", Description = "This course covers how to use the Microsoft Analysis Services development tools to create an Analysis Services database and an OLAP cube, and how to use the Analysis Services management and administrative tools to manage an Analysis Services solution. This course focuses on creating cubes with dimensions and measures, implementing data mining, and maintain and adminstration of Analysis Services." }
            };

            courses.ForEach(s => context.Courses.AddOrUpdate(p => p.Title, s));
            context.SaveChanges();

            var schedules = new List<Schedule>
            {
                new Schedule { CourseId = courses.Single(c => c.Title == "Programming in HTML5 with JavaScript and CSS3").CourseId, StartDate = DateTime.Parse("2016-08-01"), EndDate = DateTime.Parse("2016-08-05"), ClassTime = "9:00 AM - 5: 00 PM Central Time", RemainingSeats = 19 },
                new Schedule { CourseId = courses.Single(c => c.Title == "Microsoft SQL Server Database Development").CourseId, StartDate = DateTime.Parse("2016-08-08"), EndDate = DateTime.Parse("2016-08-12"), ClassTime = "9:00 AM - 5: 00 PM Central Time", RemainingSeats = 19 },
                new Schedule { CourseId = courses.Single(c => c.Title == "Programming in C#").CourseId, StartDate = DateTime.Parse("2016-08-15"), EndDate = DateTime.Parse("2016-08-19"), ClassTime = "9:00 AM - 5: 00 PM Central Time", RemainingSeats = 20 },
                new Schedule { CourseId = courses.Single(c => c.Title == "Implementing and Maintaining Microsoft SQL Server Reporting Services").CourseId, StartDate = DateTime.Parse("2016-08-22"), EndDate = DateTime.Parse("2016-08-26"), ClassTime = "9:00 AM - 5: 00 PM Central Time", RemainingSeats = 20 },
                new Schedule { CourseId = courses.Single(c => c.Title == "Developing ASP.NET MVC 4 Web Applications").CourseId, StartDate = DateTime.Parse("2016-08-29"), EndDate = DateTime.Parse("2016-09-02"), ClassTime = "9:00 AM - 5: 00 PM Central Time", RemainingSeats = 19 },
                new Schedule { CourseId = courses.Single(c => c.Title == "Implementing and Maintaining Microsoft SQL Server Integration Services").CourseId, StartDate = DateTime.Parse("2016-09-05"), EndDate = DateTime.Parse("2016-09-09"), ClassTime = "9:00 AM - 5: 00 PM Central Time", RemainingSeats = 20 },
                new Schedule { CourseId = courses.Single(c => c.Title == "Developing Windows Azure and Web Services").CourseId, StartDate = DateTime.Parse("2016-09-12"), EndDate = DateTime.Parse("2016-09-16"), ClassTime = "9:00 AM - 5: 00 PM Central Time", RemainingSeats = 19 },
                new Schedule { CourseId = courses.Single(c => c.Title == "Implementing and Maintaining Microsoft SQL Server Analysis Services").CourseId, StartDate = DateTime.Parse("2016-09-19"), EndDate = DateTime.Parse("2016-09-23"), ClassTime = "9:00 AM - 5: 00 PM Central Time", RemainingSeats = 20 }
            };

            //foreach (Schedule sc in schedules)
            //{
            //    var scheduleInDataBase = context.Schedules.Where(c => c.CourseId == sc.CourseId).SingleOrDefault();
            //    if (scheduleInDataBase != null)
            //    {
            //        context.Schedules.Add(sc);
            //    }
            //}
            schedules.ForEach(s => context.Schedules.AddOrUpdate(p => new { p.CourseId }, s));
            context.SaveChanges();

            var sessions = new List<Session>
            {
                new Session {CourseId = courses.Single(s => s.Title == "Programming in HTML5 with JavaScript and CSS3").CourseId, ScheduleId = schedules.Single(s => s.Course.Title == "Programming in HTML5 with JavaScript and CSS3" ).ScheduleId, UserId = users.Single(u => u.UserName == "smiazga").UserId },
                new Session {CourseId = courses.Single(s => s.Title == "Microsoft SQL Server Database Development").CourseId, ScheduleId = schedules.Single(s => s.Course.Title == "Microsoft SQL Server Database Development" ).ScheduleId, UserId = users.Single(u => u.UserName == "smiazga").UserId }
            };

            //foreach (Session se in sessions)
            //{
            //    var sessionInDataBase = context.Sessions.Where(c => c.CourseId == se.CourseId).SingleOrDefault();
            //    if (sessionInDataBase != null)
            //    {
            //        context.Sessions.Add(se);
            //    }
            //}
            //}
            sessions.ForEach(s => context.Sessions.AddOrUpdate(p => new { p.CourseId, p.ScheduleId }, s));
            context.SaveChanges();

        }
    }
}
