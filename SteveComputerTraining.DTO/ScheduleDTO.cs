using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteveComputerTraining.DTO
{
    public class ScheduleDTO
    {
        public int ScheduleId { get; set; }

        public int CourseId { get; set; }

        public string CourseTitle { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string ClassTime { get; set; }

        public int? RemainingSeats { get; set; }
    }
}
