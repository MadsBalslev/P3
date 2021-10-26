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
    public class ScreenZonesController : ControllerBase
    {
       private readonly databaseContext _context;

        public ScreenZonesController(databaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Zone> Get()
        {
            //await Task.Delay(3000);
            return _context.Zones.ToList();
        }

        [HttpGet("{id:int}")]
        public ActionResult<Zone> GetZoneDetails(int id)
        {
            Zone zone = _context.Zones.Where(z => z.Id == id).FirstOrDefault();

            if (zone == null)
            {
                return NotFound();
            }

            return zone;
        }

        [HttpPost]
        public ActionResult<Zone> Post([FromBody] Zone zone)
        {
            _context.Zones.Add(zone);
            _context.SaveChanges();

            return _context.Zones
            .Where(z => z.Name == zone.Name)
            .FirstOrDefault();
        }

        [HttpDelete("{id:int}")]
        public ActionResult<Zone> Delete(int id)
        {
            Zone zone = _context.Zones.Find(id);
            _context.Zones.Remove(zone);
            _context.SaveChanges();

            return zone;
        } 
    }
}