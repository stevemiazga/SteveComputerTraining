using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteveComputerTraining.WebAPI.Models
{
    public interface IComputerTrainingRepository : IDisposable
    {
        IEnumerable<Course> GetCourses();

        Course GetCourseByID(int CourseId);

        IEnumerable<Schedule> GetSchedules();

        Schedule GetScheduleByScheduleId(int ScheduleId);

        Session GetSessionBySessionId(int SessionId);

        IEnumerable<Session> GetSessionsByUser(string UserName);

        bool ExistsSessionReserveByScheduleId(string userName, int scheduleId);

        void UpdateSchedule(Schedule schedule);

        void InsertSession(Session session);

        void InsertUser(User user);

        void UpdateSession(Session session);

        void DeleteSession(int SessionId);

        void Save();

        int GetUserName(string UserName);

        void UpdateSchedulesDates();


    }
}
