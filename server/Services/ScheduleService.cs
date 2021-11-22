using System.Collections.Generic;
using System;
using System.Linq;
using server.Entities;
namespace server.Services
{
    public class ScheduleService
    {
        public ScheduleService(databaseContext context)
        {
            _context = context;
        }

        private databaseContext _context;

        public IEnumerable<Schedule> GetAllSchedules()
        {
            return _context.Schedules.ToList();
        }

        public Schedule GetSchedule(int id)
        {
            Schedule schedule = _context.Schedules.Find(id);

            if (schedule == null)
            {
                throw new NullReferenceException("Schedule was not found");
            }

            return schedule;
        }

        public Object GetScheduleJSON(int id)
        {
            Schedule s = GetSchedule(id);
            List<Object> SchedulesList = new List<Object>();

            SchedulesList.Add(s.ToJSON());

            // Unecessary loop?
            // foreach (Schedule s in u.Posters)
            // {
            //     SchedulesList.Add(s.ToJSON());
            // }

            return new
            {
                userDetail = u.ToJSON(),
                posters = uPosters,
            };
        }

        public User CreateUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();

            return _context.Users.Where(u => u.Email == user.Email).FirstOrDefault();
        }

        public User DeleteUser(int id)
        {
            User user = _context.Users.Find(id);
            _context.Users.Remove(user);
            _context.SaveChanges();

            return user;
        }

        public IEnumerable<Object> GetAllUserJSON()
        {
            IEnumerable<User> users = GetAllUsers();
            List<Object> response = new List<object>();

            foreach (User u in users)
            {
                response.Add(u.ToJSON());
            }

            return response;
        }

        // PUT request
        public User UpdateUser(int id, User user)
        {
            User u = GetUser(id);
            u.FirstName = user.FirstName;
            u.LastName = user.LastName;
            u.Email = user.Email;
            u.PhoneNumber = user.PhoneNumber;
            u.Role = user.Role;

            _context.SaveChanges();

            return u;
        }

        public Object UpdateUserJSON(int id, User user) => UpdateUser(id, user).ToJSON();
    }
}