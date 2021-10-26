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
    public class ScreensController : ControllerBase
    {
        private readonly databaseContext _context;

        public ScreensController(databaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Screen> Get()
        {
            //await Task.Delay(3000);
            return _context.Screens.ToList();
        }

        [HttpGet("{id:int}")]
        public ActionResult<Screen> GetScreenDetails(int id)
        {
            Screen screen = _context.Screens.Where(s => s.Id == id).FirstOrDefault();

            if (screen == null)
            {
                return NotFound();
            }

            return screen;
        }

        [HttpPost]
        public ActionResult<Screen> Post([FromBody] Screen screen)
        {
            _context.Screens.Add(screen);
            _context.SaveChanges();

            return _context.Screens
            .Where(s => s.Name == screen.Name)
            .FirstOrDefault();
        }

        [HttpDelete("{id:int}")]
        public ActionResult<Screen> Delete(int id)
        {
            Screen screen = _context.Screens.Find(id);
            _context.Screens.Remove(screen);
            _context.SaveChanges();

            return screen;
        }
    }
}