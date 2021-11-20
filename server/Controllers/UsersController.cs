using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.Entities;
using server.Services;

namespace server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private UserService _userService;
        private databaseContext _context;

        public UsersController(databaseContext context)
        {
            _userService = new UserService(context);
        }

        [HttpGet]
        public IEnumerable<Object> Get()
        {
            return _userService.GetAllUserJSON();
        }

        [HttpGet("GetUser")]
        public async Task<ActionResult<Object>> GetUser()
        {
            string email = HttpContext.User.Identity.Name;
            User user = await _context.Users.Where(u => u.Email == email).FirstOrDefaultAsync();
            return _userService.GetUserJSON(user.Id);
        }

        [HttpGet("{id:int}")]
        public ActionResult<Object> GetUserDetails(int id)
        {
            try
            {
                Object user = _userService.GetUserJSON(id);
                return user;
            }
            catch (System.NullReferenceException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult<Object> Post([FromBody] User user)
        {
            try
            {
                User u = _userService.CreateUser(user);
                return _userService.GetUserJSON(u.Id);
            }
            catch (System.Exception)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id:int}")]
        public ActionResult<Object> Delete(int id)
        {
            try
            {
                Object u = _userService.GetUserJSON(id);
                _userService.DeleteUser(id);
                return u;
            }
            catch (System.Exception)
            {
                return NotFound();
            }
        }

        [HttpPut("{id:int}")]
        public ActionResult<Object> Put([FromBody] User user, int id) => _userService.UpdateUserJSON(id, user);
    }
}