using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.Entities;
using server.Services;

namespace server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostersController : ControllerBase
    {
        //private readonly databaseContext _context;
        private PosterService _posterService;
        private UserService _userService;

        public PostersController(databaseContext context)
        {
            _posterService = new PosterService(context);
            _userService = new UserService(context);
        }

        [HttpGet]
        public async Task<IEnumerable<Object>> Get()
        {
            string email = HttpContext.User.Identity.Name;
            User currentUser = await _userService.GetLoggedInUser(email);
            try
            {
                return await _posterService.GetAllPosterJSON(currentUser);
            }
            catch (System.Exception)
            {
                System.Console.WriteLine("This fucked up");
                return Enumerable.Empty<Object>();
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Object>> GetPosterDetails(int id)
        {
            try
            {
                return await _posterService.GetPosterJSON(id);
            }
            catch (System.Exception)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<ActionResult<Object>> Post([FromBody] Poster poster)
        {
            try
            {
                Poster p = await _posterService.CreatePoster(poster);
                return p.ToJSON();
            }
            catch (System.Exception e)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Object>> Delete(int id)
        {
            try
            {
                Object p = await _posterService.GetPosterJSON(id);
                await _posterService.DeletePoster(id);
                return p;
            }
            catch (System.Exception)
            {
                return NotFound();
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Object>> Put([FromBody] Poster p, int id) => await _posterService.UpdatePosterJSON(id, p);
    }
}
