using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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
        public async Task<IEnumerable<Screen>> GetAllScreens() => await _context.Screens.ToListAsync();
        public async Task<IEnumerable<Object>> GetAllScreensJSON()
        {
            IEnumerable<Screen> screens = await GetAllScreens();
            List<Object> response = new List<Object>();

            foreach (Screen s in screens)
            {
                response.Add(s.ToJSON());
            }

            return response;
        }

        public async Task<Screen> GetScreen(int id)
        {
            Screen s = await _context.Screens.FindAsync(id);
            if (s == null)
            {
                throw new NullReferenceException("Screen not found");
            }

            return s;
        }

        public async Task<Object> GetScreenJSON(int id)
        {
            Screen s = await GetScreen(id);

            return s.ToJSON();
        }

        // Post requests
        public async Task<Screen> CreateScreen(Screen screen)
        {
            await _context.Screens.AddAsync(screen);
            await _context.SaveChangesAsync();

            return await _context.Screens.Where(s => s.Name == screen.Name && s.Zone == screen.Zone).FirstOrDefaultAsync();
        }

        // Delete request
        public async Task<Screen> DeleteScreen(int id)
        {
            Screen screen = await _context.Screens.FindAsync(id);
            _context.Screens.Remove(screen);
            await _context.SaveChangesAsync();

            return screen;
        }

        // PUT request
        public async Task<Screen> UpdateScreen(int id, Screen screen)
        {
            Screen s = await GetScreen(id);
            s.Name = screen.Name;
            s.Zone = screen.Zone;

            await _context.SaveChangesAsync();

            return s;
        }

        public async Task<Object> UpdateScreenJSON(int id, Screen screen)
        {
            Screen s = await UpdateScreen(id, screen);
            return s.ToJSON();
        }
    }
}