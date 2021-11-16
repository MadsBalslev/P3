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
    public class PostersController : ControllerBase
    {
        //private readonly databaseContext _context;
        private PosterService _posterService;

        public PostersController(databaseContext context)
        {
            _posterService = new PosterService(context);
        }

        [HttpGet]
        public IEnumerable<Object> Get()
        {
            return _posterService.GetAllPosterJSON();
        }

        [HttpGet("{id:int}")]
        public ActionResult<Object> GetPosterDetails(int id)
        {
            try
            {
                return _posterService.GetPosterJSON(id);
            }
            catch (System.Exception)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult<Object> Post([FromBody] Poster poster)
        {
             if (_posterService.SanityCheck(poster) != "")
            {
                return BadRequest(_posterService.SanityCheck(poster));
            }
            try
            {
                Poster p = _posterService.CreatePoster(poster);
                return _posterService.GetPosterJSON(p.Id);
            }
            // Does not only catch invalid id errors, but also others.
            catch (System.Exception)
            {

                return BadRequest("Id does not exist");
            }
        }

        [HttpDelete("{id:int}")]
        public ActionResult<Object> Delete(int id)
        {

            try
            {
                Object p = _posterService.GetPosterJSON(id);
                _posterService.DeletePoster(id);
                return p;
            }
            catch (System.Exception)
            {
                return NotFound();
            }
        }

        [HttpPut("{id:int}")]
        public ActionResult<Object> Put([FromBody] Poster p, int id) => _posterService.UpdatePosterJSON(id, p);
    }
}