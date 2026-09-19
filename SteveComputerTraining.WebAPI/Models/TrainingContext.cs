namespace SteveComputerTraining.WebAPI.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TrainingContext : DbContext
    {
        public TrainingContext()
            : base("name=TrainingContext")
        {
        }

        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Schedule> Schedules { get; set; }
        public virtual DbSet<Session> Sessions { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>()
                .Property(e => e.Category)
                .IsUnicode(false);

            modelBuilder.Entity<Course>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<Course>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Course>()
                .HasMany(e => e.Schedules)
                .WithRequired(e => e.Course)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Schedule>()
                .Property(e => e.ClassTime)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.UserName)
                .IsUnicode(false);
        }
    }
}
