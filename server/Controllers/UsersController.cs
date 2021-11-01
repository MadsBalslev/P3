using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.Models;
using server.Services;

namespace server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        // private readonly databaseContext _context;
        private UserService _userService;

        public UsersController(databaseContext context)
        {
            _userService = new UserService(context);
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _userService.GetAllUsers();
            // return _context.Users.ToList();
        }

        // [HttpGet("{id:int}")]
        // public ActionResult<User> GetUserDetails(int id)
        // {
        //     User user = _context.Users.Where(u => u.Id == id).FirstOrDefault();

        //     if (user == null)
        //     {
        //         return NotFound();
        //     }

        //     return user;
        // }

        // [HttpPost]
        // public ActionResult<User> Post([FromBody] User user)
        // {
        //     _context.Users.Add(user);
        //     _context.SaveChanges();

        //     return _context.Users.Where(u => u.Email == user.Email).FirstOrDefault();
        // }

        // [HttpDelete("{id:int}")]
        // public ActionResult<User> Delete(int id)
        // {
        //     User user = _context.Users.Find(id);
        //     _context.Users.Remove(user);
        //     _context.SaveChanges();

        //     return user;
        // }
    }
}