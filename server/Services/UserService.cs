using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using server.Entities;
using BCryptNet = BCrypt.Net.BCrypt;

namespace server.Services
{
    public class UserService
    {
        public UserService(databaseContext context)
        {
            _context = context;
            _instService = new InstitutionService(context);
        }

        private databaseContext _context;
        InstitutionService _instService;


        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _context.Users
                .Include(u => u.InstitutionNavigation)
                .ToListAsync();
        }

        public async Task<User> GetUser(int id)
        {
            User user = await _context.Users
                .Include(u => u.InstitutionNavigation)
                .Where(u => u.Id == id)
                .FirstOrDefaultAsync();

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

            return u.ToJSON();
            // return new
            // {
            //     userDetail = u.ToJSON(),
            //     posters = uPosters,
            // };
        }

        public async Task<User> CreateUser(User user)
        {
            if (_context.Users.Any(u => u.Email == user.Email))
                throw new ApplicationException("Email: " + user.Email + "is already taken");

            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
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
            List<Object> response = new List<Object>();

            foreach (User u in users)
            {
                response.Add(
                    u.ToJSON()
                );
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