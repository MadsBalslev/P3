using System.Collections.Generic;
using System;
using System.Linq;
using server.Models;
namespace server.Services
{
    public class UserService
    {
        public UserService(databaseContext context)
        {
            _context = context;
        }

        private databaseContext _context;

        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public User GetUser(int id)
        {
            User user = _context.Users.Find(id);

            if (user == null)
            {
                throw new NullReferenceException("User was not found");
            }

            return user;
        }

        public Object GetUserJSON(int id)
        {
            User u = GetUser(id);
            List<Object> uPosters = new List<Object>();
            foreach (Poster p in u.Posters)
            {
                uPosters.Add(p.ToJSON());
            }

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
    }
}