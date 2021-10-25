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
    public class PostersController : ControllerBase
    {
        private readonly databaseContext _context;

        public PostersController(databaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Poster> Get()
        {
            //await Task.Delay(3000);
            return _context.Posters.ToList();
        }

        [HttpGet("{id:int}")]
        public ActionResult<Poster> GetPosterDetails(int id)
        {
            Poster poster = _context.Posters.Where(p => p.Id == id).FirstOrDefault();

            if (poster == null)
            {
                return NotFound();
            }

            return poster;
        }

        [HttpPost]
        public ActionResult<Poster> Post([FromBody] Poster poster)
        {
            _context.Posters.Add(poster);
            _context.SaveChanges();

            return _context.Posters.Where(p => p.Name == poster.Name && p.Institution == poster.Institution).FirstOrDefault();
        }

        [HttpDelete("{id:int}")]
        public ActionResult<Poster> Delete(int id)
        {
            Poster poster = _context.Posters.Find(id);
            _context.Posters.Remove(poster);
            _context.SaveChanges();

            return poster;
        }
    }
}