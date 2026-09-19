namespace SteveComputerTraining.WebAPI.Migrations.TrainingContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDatabaseCreation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Course",
                c => new
                    {
                        CourseId = c.Int(nullable: false, identity: true),
                        Category = c.String(maxLength: 50, unicode: false),
                        Title = c.String(unicode: false),
                        Description = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.CourseId);
            
            CreateTable(
                "dbo.Schedule",
                c => new
                    {
                        ScheduleId = c.Int(nullable: false, identity: true),
                        CourseId = c.Int(nullable: false),
                        StartDate = c.DateTime(storeType: "date"),
                        EndDate = c.DateTime(storeType: "date"),
                        ClassTime = c.String(maxLength: 50, unicode: false),
                        RemainingSeats = c.Int(),
                    })
                .PrimaryKey(t => t.ScheduleId)
                .ForeignKey("dbo.Course", t => t.CourseId)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.Session",
                c => new
                    {
                        SessionId = c.Int(nullable: false, identity: true),
                        CourseId = c.Int(nullable: false),
                        ScheduleId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SessionId)
                .ForeignKey("dbo.Course", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Schedule", t => t.ScheduleId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.CourseId)
                .Index(t => t.ScheduleId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Schedule", "CourseId", "dbo.Course");
            DropForeignKey("dbo.Session", "UserId", "dbo.User");
            DropForeignKey("dbo.Session", "ScheduleId", "dbo.Schedule");
            DropForeignKey("dbo.Session", "CourseId", "dbo.Course");
            DropIndex("dbo.Session", new[] { "UserId" });
            DropIndex("dbo.Session", new[] { "ScheduleId" });
            DropIndex("dbo.Session", new[] { "CourseId" });
            DropIndex("dbo.Schedule", new[] { "CourseId" });
            DropTable("dbo.User");
            DropTable("dbo.Session");
            DropTable("dbo.Schedule");
            DropTable("dbo.Course");
        }
    }
}
