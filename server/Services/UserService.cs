using System.Collections.Generic;
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
    }
}