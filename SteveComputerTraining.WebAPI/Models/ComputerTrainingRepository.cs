using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace SteveComputerTraining.WebAPI.Models
{
    public class ComputerTrainingRepository : IComputerTrainingRepository
    {
        private TrainingContext context;

        public ComputerTrainingRepository(TrainingContext context)
        {
            this.context = context;
        }

        public Course GetCourseByID(int courseId)
        {
            return context.Courses.Find(courseId);
        }

        public IEnumerable<Course> GetCourses()
        {
            return context.Courses.ToList();
        }

        public IEnumerable<Schedule> GetSchedules()
        {
            return context.Schedules.ToList().OrderBy(s => s.StartDate);
        }

        public Schedule GetScheduleByScheduleId(int ScheduleId)
        {
            return context.Schedules.Find(ScheduleId);
        }

        public Session GetSessionBySessionId(int SessionId)
        {
            return context.Sessions.Find(SessionId);
        }

        public IEnumerable<Session> GetSessionsByUser(string userName)
        {
            int userId = GetUserName(userName);

            return context.Sessions.Where(u => u.UserId == userId);
        }

        public int GetUserName(string userName)
        {
            return context.Users.Where(u => u.UserName == userName).Select(i => i.UserId).FirstOrDefault();
        }

        public bool ExistsSessionReserveByScheduleId(string userName, int scheduleId)
        {
            int userId = GetUserName(userName);

            return context.Sessions.Where(u => u.UserId == userId && u.ScheduleId == scheduleId).ToList().Any();
        }

        public void InsertSession(Session session)
        {
            context.Sessions.Add(session);
        }

        public void InsertUser(User user)
        {
            context.Users.Add(user);
        }

        public void DeleteSession(int sessionId)
        {
            Session session = context.Sessions.Find(sessionId);
            context.Sessions.Remove(session);
        }

        public void UpdateSchedule(Schedule schedule)
        {
            context.Entry(schedule).State = EntityState.Modified;
        }

        public void UpdateSchedulesDates()
        {
            DateTime? minScheduleDate = context.Schedules.Select(d => d.EndDate).Min();
            int newYear = DateTime.Now.Year;
            int newMonth = DateTime.Now.Month;
            DateTime newDates = DateTime.Now;
            DateTime newStartDate = newDates;
            DateTime newEndDate = newDates;
            int iStartDays = 0;
            int iEndDays = 0;
            while (newStartDate.DayOfWeek != DayOfWeek.Monday)
            {
                newStartDate = newStartDate.AddDays(1);
            }
            newEndDate = newStartDate.AddDays(4);

            if (minScheduleDate != null)
            {
                if (minScheduleDate < newDates)
                {
                    IEnumerable<Schedule> scheduleDateUp = GetSchedules();
                    foreach (var d in scheduleDateUp)
                    {

                        d.StartDate = d.StartDate.HasValue ? newStartDate.AddDays(iStartDays) : d.StartDate;
                        d.EndDate = d.EndDate.HasValue ? newEndDate.AddDays(iEndDays) : d.EndDate;

                        context.Entry(d).State = EntityState.Modified;

                        iStartDays = iStartDays + 7;
                        iEndDays = iStartDays + 4;
                    }

                    //context.Schedules.ToList().ForEach(d => d.StartDate = d.StartDate.HasValue ? newStartDate : d.StartDate);
                    //context.Schedules.ToList().ForEach(d => d.EndDate = d.EndDate.HasValue ? newEndDate : d.EndDate);
                    context.SaveChanges();

                }
            }
        }


        public void UpdateSession(Session session)
        {
            context.Entry(session).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
