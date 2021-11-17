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
    public class ZonesController : ControllerBase
    {
        private ZoneService _zoneService;

        public ZonesController(databaseContext context)
        {
            _zoneService = new ZoneService(context);
        }

        [HttpGet]
        public IEnumerable<Object> Get() => _zoneService.GetAllZonesJSON();

        [HttpGet("{id:int}")]
        public ActionResult<Object> GetZoneDetails(int id)
        {
            try
            {
                Object zone = _zoneService.GetZoneJSON(id);
                return zone;
            }
            catch (System.NullReferenceException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult<Object> Post([FromBody] Zone zone)
        {
            try
            {
                Zone z = _zoneService.CreateZone(zone);
                return _zoneService.GetZoneJSON(z.Id);
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
                Object z = _zoneService.GetZoneJSON(id);
                _zoneService.DeleteZone(id);
                return z;
            }
            catch (System.Exception)
            {
                return NotFound();
            }
        }

        [HttpPut("{id:int}")]
        public ActionResult<Object> Put([FromBody] Zone z, int id) => _zoneService.UpdateZoneJSON(id, z);
    }
}