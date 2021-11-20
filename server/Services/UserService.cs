using System.Collections.Generic;
using System;
using System.Linq;
using server.Entities;
using BCryptNet = BCrypt.Net.BCrypt;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace server.Services
{
    public class UserService
    {
        public UserService(databaseContext context)
        {
            _context = context;
        }

        private databaseContext _context;

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUser(int id)
        {
            User user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                throw new NullReferenceException("User was not found");
            }

            return user;
        }

        public async Task<Object> GetUserJSON(int id)
        {
            User u = await GetUser(id);
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

        public async Task<User> CreateUser(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return await _context.Users.Where(u => u.Email == user.Email).FirstOrDefaultAsync();
        }

        public async Task<User> DeleteUser(int id)
        {
            User user = await _context.Users.FindAsync(id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<IEnumerable<Object>> GetAllUserJSON()
        {
            IEnumerable<User> users = await GetAllUsers();
            List<Object> response = new List<object>();

            foreach (User u in users)
            {
                response.Add(u.ToJSON());
            }

            return response;
        }

        // PUT request
        public async Task<User> UpdateUser(int id, User user)
        {
            User u = await GetUser(id);
            u.FirstName = user.FirstName;
            u.LastName = user.LastName;
            u.Email = user.Email;
            u.PhoneNumber = user.PhoneNumber;
            u.Role = user.Role;

            await _context.SaveChangesAsync();

            return u;
        }

        public async Task<Object> UpdateUserJSON(int id, User user)
        {
            User u = await UpdateUser(id, user);
            return u.ToJSON();
        }
    }
}