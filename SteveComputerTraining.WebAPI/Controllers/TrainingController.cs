using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using SteveComputerTraining.WebAPI.Models;
using SteveComputerTraining.DTO;

namespace SteveComputerTraining.WebAPI.Controllers
{
    //[EnableCors("http://localhost:6541", "*", "*")]
    //[EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api")]
    public class TrainingController : ApiController
    {

        private IComputerTrainingRepository trainingRepository;

        public TrainingController()
        {
            this.trainingRepository = new ComputerTrainingRepository(new TrainingContext());
        }

        public TrainingController(IComputerTrainingRepository trainingRepository)
        {
            this.trainingRepository = trainingRepository;
        }


        [Route("courses")]
        public IHttpActionResult GetCourses()
        {
            try
            {
                var courses = trainingRepository.GetCourses();

                var coursesDTO = from c in courses.ToList()
                                 select new CourseDTO
                                 {
                                     CourseId = c.CourseId,
                                     Category = c.Category,
                                     Title = c.Title,
                                     Description = c.Description
                                 };

                return Ok(coursesDTO);

            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
        }

        [Route("courses/{id:int}")]
        public IHttpActionResult GetCourseByID(int id)
        {
            try
            {
                var course = trainingRepository.GetCourseByID(id);

                CourseDTO courseDTO = new CourseDTO()
                {
                    CourseId = course.CourseId,
                    Category = course.Category,
                    Title = course.Title,
                    Description = course.Description
                };

                if (courseDTO == null)
                {
                    return NotFound();
                }

                return Ok(courseDTO);

            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
        }

        [Route("schedules")]
        public IHttpActionResult GetSchedules()
        {
            try
            {
                var schedules = trainingRepository.GetSchedules();

                var schedulesDTO = from s in schedules.ToList()
                                   select new ScheduleDTO
                                   {
                                       ScheduleId = s.ScheduleId,
                                       CourseId = s.CourseId,
                                       CourseTitle = s.Course.Title,
                                       StartDate = s.StartDate,
                                       EndDate = s.EndDate,
                                       ClassTime = s.ClassTime,
                                       RemainingSeats = s.RemainingSeats
                                   };
                                   

                return Ok(schedulesDTO);

            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
        }

        [Route("schedules/{id:int}")]
        public IHttpActionResult GetScheduleByScheduleId(int id)
        {
            try
            {
                var schedule = trainingRepository.GetScheduleByScheduleId(id);

                ScheduleDTO scheduleDTO = new ScheduleDTO()
                {
                    ScheduleId = schedule.ScheduleId,
                    CourseId = schedule.CourseId,
                    CourseTitle = schedule.Course.Title,
                    StartDate = schedule.StartDate,
                    EndDate = schedule.EndDate,
                    ClassTime = schedule.ClassTime,
                    RemainingSeats = schedule.RemainingSeats
                };

                if (scheduleDTO == null)
                {
                    return NotFound();
                }

                return Ok(scheduleDTO);

            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
        }

        [Route("schedules/{id:int}")]
        public IHttpActionResult PutSchedule(int id, [FromBody]ScheduleDTO scheduledto)
        {
            try
            {
                if (scheduledto == null)
                {
                    return BadRequest("Schedule cannot be null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                Schedule schedule = new Schedule
                {
                    ScheduleId = scheduledto.ScheduleId,
                    CourseId = scheduledto.CourseId,
                    StartDate = scheduledto.StartDate,
                    EndDate = scheduledto.EndDate,
                    ClassTime = scheduledto.ClassTime,
                    RemainingSeats = scheduledto.RemainingSeats
                };

                if (schedule == null)
                {
                    return NotFound();
                }

                trainingRepository.UpdateSchedule(schedule);
                trainingRepository.Save();

                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [Route("schedules/dates/")]
        public IHttpActionResult PutScheduleDates()
        {
            try
            {

                trainingRepository.UpdateSchedulesDates();

                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [Route("sessions/{userName}")]
        public IHttpActionResult GetSessionsByUser(string userName)
        {
            try
            {
                var sessions = trainingRepository.GetSessionsByUser(userName);

                var sessionsDTO = from s in sessions.ToList()
                                  select new SessionDTO
                                  {
                                      SessionId = s.SessionId,
                                      CourseId = s.CourseId,
                                      CourseTitle = s.Course.Title,
                                      ScheduleId = s.ScheduleId,
                                      StartDate = s.Schedule.StartDate,
                                      EndDate = s.Schedule.EndDate,
                                      ClassTime = s.Schedule.ClassTime,
                                      UserId = s.UserId,
                                      UserName = s.User.UserName
                                  };

                return Ok(sessionsDTO);

            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
        }

        [Route("sessions/{userName}/exists/{id:int}")]
        public IHttpActionResult GetExistsSessionReserveByScheduleId(string userName, int id)
        {
            try
            {
                var exists = trainingRepository.ExistsSessionReserveByScheduleId(userName,id);

                return Ok(exists);

            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
        }

        [Route("sessions/{id:int}")]
        public IHttpActionResult GetSessionBySessionId(int id)
        {
            try
            {
                var session = trainingRepository.GetSessionBySessionId(id);

                SessionDTO sessionDTO = new SessionDTO()
                {
                   SessionId = session.SessionId,
                   CourseId = session.CourseId,
                   CourseTitle = session.Course.Title,
                   ScheduleId = session.ScheduleId,
                   StartDate = session.Schedule.StartDate,
                   EndDate = session.Schedule.EndDate,
                   ClassTime = session.Schedule.ClassTime,
                   UserId = session.User.UserId,
                   UserName = session.User.UserName
                };

                if (sessionDTO == null)
                {
                    return NotFound();
                }

                return Ok(sessionDTO);

            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
        }

        [Route("sessions")]
        public IHttpActionResult PostSession([FromBody]SessionDTO sessiondto)
        {
            try
            {
                if (sessiondto == null)
                {
                    return BadRequest("Session cannot be null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                int userId = trainingRepository.GetUserName(sessiondto.UserName);

                Session session = new Session
                {
                    CourseId = sessiondto.CourseId,
                    ScheduleId = sessiondto.ScheduleId,
                    UserId = userId
                };

                trainingRepository.InsertSession(session);
                trainingRepository.Save();

                //return CreatedAtRoute("DefaultApi", new { id = session.SessionId }, session);
                return Ok();

            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [Route("sessions/{id:int}")]
        public IHttpActionResult PutSession(int id, [FromBody]SessionDTO sessiondto)
        {
            try
            {
                if (sessiondto == null)
                {
                    return BadRequest("Session cannot be null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                Session session = new Session
                {
                    SessionId = sessiondto.SessionId,
                    CourseId = sessiondto.CourseId,
                    ScheduleId = sessiondto.ScheduleId,
                    UserId = sessiondto.UserId
                };

                if (session == null)
                {
                    return NotFound();
                }

                trainingRepository.UpdateSession(session);
                trainingRepository.Save();

                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [Route("sessions/{id:int}")]
        public IHttpActionResult DeleteSession(int id)
        {
            try
            {
                trainingRepository.DeleteSession(id);
                trainingRepository.Save();

                 return StatusCode(HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [Route("user/{userName}")]
        public IHttpActionResult PostUserName(string userName)
        {
            try
            {
                if (userName == null)
                {
                    return BadRequest("User Name cannot be null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                User user= new User
                {
                    UserName = userName
                };

                trainingRepository.InsertUser(user);
                trainingRepository.Save();

                //return CreatedAtRoute("DefaultApi", new { id = session.SessionId }, session);
                return Ok();

            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
