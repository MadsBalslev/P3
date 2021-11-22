using System;
using System.Linq;
using System.Text;
using server.Entities;

namespace server.Services
{
    public class LoginService
    {
        private databaseContext _context;

        private string Base64Encode(string plainText)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }

        public LoginService(databaseContext context)
        {
            _context = context;
        }

        public string Login(string email, string pswd)
        {
            User user = _context.Users.Where(u => u.Email == email).FirstOrDefault();

            if (!BCrypt.Net.BCrypt.Verify(pswd, user.Password))
                throw new ApplicationException("Email or Password not correct");

            return Base64Encode(email + ":" + user.Password);
        }
    }
}