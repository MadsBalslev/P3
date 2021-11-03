using System.Collections.Generic;
using System;
using System.Linq;
using server.Models;
namespace server.Services
{
    public class ZoneService
    {
        private readonly databaseContext _context;
        public ZoneService(databaseContext context)
        {
            _context = context;
        }

        public IEnumerable<Zone> GetAllZones() => _context.Zones.ToList();

        // Get requests
        public IEnumerable<Object> GetAllZonesJSON()
        {
            IEnumerable<Zone> zones = GetAllZones();
            List<Object> response = new List<Object>();
            foreach (Zone z in zones)
            {
                response.Add(z.ToJSON());
            }

            return response;
        }

        public Zone GetZone(int id)
        {
            Zone zone = _context.Zones.Find(id);

            if (zone == null)
            {
                throw new NullReferenceException("Zone was not found");
            }

            return zone;
        }

        public Object GetZoneJSON(int id)
        {
            Zone z = GetZone(id);
            List<Object> zScreens = new List<Object>();
            foreach (Screen s in z.Screens)
            {
                zScreens.Add(s.ToJSON());
            }

            return new
            {
                zoneDetaile = z.ToJSON(),
                screens = zScreens,
            };
        }

        // Post requests
        public Zone CreateZone(Zone zone)
        {
            _context.Zones.Add(zone);
            _context.SaveChanges();

            return _context.Zones.Where(z => z.Name == zone.Name).FirstOrDefault();
        }

        // Delete requests
        public Zone DeleteZone(int id)
        {
            Zone zone = _context.Zones.Find(id);
            _context.Zones.Remove(zone);
            _context.SaveChanges();

            return zone;
        }
    }
}