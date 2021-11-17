using System;
using System.Collections.Generic;
using System.Linq;
using server.Entities;

namespace server.Services
{
    public class ScreenService
    {
        private readonly databaseContext _context;

        public ScreenService(databaseContext context)
        {
            _context = context;
        }

        // Get requests
        public IEnumerable<Screen> GetAllScreens() => _context.Screens.ToList();
        public IEnumerable<Object> GetAllScreensJSON()
        {
            IEnumerable<Screen> screens = GetAllScreens();
            List<Object> response = new List<Object>();

            foreach (Screen s in screens)
            {
                response.Add(s.ToJSON());
            }

            return response;
        }

        public Screen GetScreen(int id)
        {
            Screen s = _context.Screens.Find(id);
            if (s == null)
            {
                throw new NullReferenceException("Screen not found");
            }

            return s;
        }

        public Object GetScreenJSON(int id) => GetScreen(id).ToJSON();

        // Post requests
        public Screen CreateScreen(Screen screen)
        {
            _context.Screens.Add(screen);
            _context.SaveChanges();

            return _context.Screens.Where(s => s.Name == screen.Name && s.Zone == screen.Zone).FirstOrDefault();
        }

        // Delete request
        public Screen DeleteScreen(int id)
        {
            Screen screen = _context.Screens.Find(id);
            _context.Screens.Remove(screen);
            _context.SaveChanges();

            return screen;
        }

        // PUT request
        public Screen UpdateScreen(int id, Screen screen)
        {
            Screen s = GetScreen(id);
            s.Name = screen.Name;
            s.Zone = screen.Zone;

            _context.SaveChanges();

            return s;
        }

        public Object UpdateScreenJSON(int id, Screen screen) => UpdateScreen(id, screen).ToJSON();

    }
}