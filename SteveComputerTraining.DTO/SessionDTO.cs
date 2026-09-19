using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteveComputerTraining.DTO
{
    public class SessionDTO
    {
        public int SessionId { get; set; }

        public int CourseId { get; set; }

        public string CourseTitle { get; set; }

        public int ScheduleId { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string ClassTime { get; set; }

        public int UserId { get; set; }

        public string UserName { get; set; }

    }
}
