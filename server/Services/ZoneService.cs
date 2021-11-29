using System.Collections.Generic;
using System;
using System.Linq;
using server.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace server.Services
{
    public class ZoneService
    {
        private readonly databaseContext _context;
        public ZoneService(databaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Zone>> GetAllZones() => await _context.Zones.ToListAsync();

        // Get requests
        public async Task<IEnumerable<Object>> GetAllZonesJSON()
        {
            IEnumerable<Zone> zones = await GetAllZones();
            List<Object> response = new List<Object>();
            foreach (Zone z in zones)
            {
                response.Add(z.ToJSON());
            }

            return response;
        }

        public async Task<Zone> GetZone(int id)
        {
            Zone zone = await _context.Zones.FindAsync(id);

            if (zone == null)
            {
                throw new NullReferenceException("Zone was not found");
            }

            return zone;
        }

        public async Task<Object> GetZoneJSON(int id)
        {
            Zone z = await GetZone(id);

            return new
            {
                zoneDetaile = z.ToJSON(),
            };
        }

        // Post requests
        public async Task<Zone> CreateZone(Zone zone)
        {
            await _context.Zones.AddAsync(zone);
            await _context.SaveChangesAsync();

            return zone;
        }

        // Delete requests
        public async Task<Zone> DeleteZone(int id)
        {
            Zone zone = await _context.Zones.FindAsync(id);
            _context.Zones.Remove(zone);
            await _context.SaveChangesAsync();

            return zone;
        }

        // PUT request
        public async Task<Zone> UpdateZone(int id, Zone zone)
        {
            Zone z = await GetZone(id);
            z.Name = zone.Name;

            await _context.SaveChangesAsync();

            return z;
        }

        public async Task<Object> UpdateZoneJSON(int id, Zone zone)
        {
            Zone z = await UpdateZone(id, zone);
            return z.ToJSON();
        }

        public async Task<IEnumerable<Object>> GetActiveSchedulesInZoneJSON(int zone_id)
        {
            DateTime currentTime = DateTime.Now;

            IEnumerable<Schedule> schedules = await _context.Schedules.ToListAsync();
            IEnumerable<Schedule> FilteredSchedules = schedules.Where(s => s.StartDate <= currentTime && s.EndDate >= currentTime && s.Zone == zone_id);

            List<Object> response = new List<Object>();
            foreach (Schedule s in FilteredSchedules)
            {
                response.Add(s.ToJSON());
            }

            return response;
        }

        public async Task<IEnumerable<Object>> GetActivePostersJSON(int zone_id)
        {
            DateTime currentTime = DateTime.Now;

            //IEnumerable<Poster> posters = await _context.Posters.ToListAsync();
            IEnumerable<Schedule> schedules = await _context.Schedules.ToListAsync();

            IEnumerable<Schedule> FilteredSchedules = schedules.Where(s => s.StartDate <= currentTime && s.EndDate >= currentTime && s.Zone == zone_id);

            //List<Object> PosterResponse = new List<Object>();

            List<Object> response = new List<Object>();
            foreach (Schedule s in FilteredSchedules)
            {
                response.Add(s.PosterToJSON());
            }

            return response;
        }


    }
}