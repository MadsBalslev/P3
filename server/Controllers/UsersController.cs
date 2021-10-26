using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.Models;

namespace server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly databaseContext _context;

        public UsersController(databaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            //await Task.Delay(3000);
            return _context.Users.ToList();
        }

        [HttpGet("{id:int}")]
        public ActionResult<User> GetUserDetails(int id)
        {
            User user = _context.Users.Where(u => u.Id == id).FirstOrDefault();

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        [HttpPost]
        public ActionResult<User> Post([FromBody] User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();

            return _context.Users.Where(u => u.Email == user.Email).FirstOrDefault();
        }

        [HttpDelete("{id:int}")]
        public ActionResult<User> Delete(int id)
        {
            User user = _context.Users.Find(id);
            _context.Users.Remove(user);
            _context.SaveChanges();

            return user;
        }
    }
}