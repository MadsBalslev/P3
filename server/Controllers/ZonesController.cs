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
        public async Task<IEnumerable<Object>> Get() => await _zoneService.GetAllZonesJSON();

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Object>> GetZoneDetails(int id)
        {
            try
            {
                Object zone = await _zoneService.GetZoneJSON(id);
                return zone;
            }
            catch (System.NullReferenceException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<ActionResult<Object>> Post([FromBody] Zone zone)
        {
            try
            {
                Zone z = await _zoneService.CreateZone(zone);
                return await _zoneService.GetZoneJSON(z.Id);
            }
            catch (System.Exception)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Object>> Delete(int id)
        {
            try
            {
                Object z = await _zoneService.GetZoneJSON(id);
                await _zoneService.DeleteZone(id);
                return z;
            }
            catch (System.Exception)
            {
                return NotFound();
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Object>> Put([FromBody] Zone z, int id) => await _zoneService.UpdateZoneJSON(id, z);

        [HttpGet("/Zones/Active/{zone_id:int}")]
        public async Task<IEnumerable<Object>> GetActiveSchedulesInZone(int zone_id)
        {
            return await _zoneService.GetActiveSchedulesInZoneJSON(zone_id);
        }
    }
}