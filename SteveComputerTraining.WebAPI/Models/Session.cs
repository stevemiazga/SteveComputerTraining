namespace SteveComputerTraining.WebAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Session")]
    public partial class Session
    {
        public int SessionId { get; set; }

        public int CourseId { get; set; }

        public int ScheduleId { get; set; }

        public int UserId { get; set; }

        public virtual Course Course { get; set; }

        public virtual Schedule Schedule { get; set; }

        public virtual User User { get; set; }
    }
}
