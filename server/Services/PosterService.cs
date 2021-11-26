using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using server.Entities;
namespace server.Services
{
    public class PosterService
    {
        public PosterService(databaseContext context)
        {
            _context = context;
        }

        private databaseContext _context;

        public async Task<IEnumerable<Poster>> GetAllPosters()
        {
            return await _context.Posters.ToListAsync();
        }

        public async Task<Poster> GetPoster(int id)
        {
            Poster poster = await _context.Posters.FindAsync(id);

            if (poster == null)
            {
                throw new NullReferenceException("Poster was not found");
            }

            return poster;
        }

        public async Task<Object> GetPosterJSON(int id)
        {
            Poster p = await GetPoster(id);
            return p.ToJSON();
        }

        public async Task<Poster> CreatePoster(Poster poster)
        {
            await _context.Posters.AddAsync(poster);
            await _context.SaveChangesAsync();
            try
            {
                 Poster createdPoster = await _context.Posters.Where(p => p.Name == poster.Name && p.Institution == poster.Institution).FirstOrDefaultAsync();
                 Console.WriteLine($"Found poster with id: {createdPoster.Id}");
                 return createdPoster;
            }
            catch (System.Exception)
            {
                System.Console.WriteLine($"Poster named {poster.Name} and Instition {poster.Institution} not found");
                return new Poster();
            }
        }

        public async Task<Poster> DeletePoster(int id)
        {
            Poster poster = await _context.Posters.FindAsync(id);
            _context.Posters.Remove(poster);
            await _context.SaveChangesAsync();

            return poster;
        }


        public async Task<IEnumerable<Object>> GetAllPosterJSON(User currentUser)
        {
            IEnumerable<Poster> result = Enumerable.Empty<Poster>();
            IEnumerable<Poster> posters = await GetAllPosters();
            System.Console.WriteLine($"Num of posters in result: {result.Count()}");
            System.Console.WriteLine($"Num of posters: {posters.Count()}");
            if (currentUser.Role == 1 || currentUser.Role == 2)
            {
                System.Console.WriteLine("Filtering out posters not related to institution");
                result = posters.Where(p => p.Institution == currentUser.Institution);
                System.Console.WriteLine($"Num of posters in result: {result.Count()}");
            }
            else if (currentUser.Role == 3)
            {
                result = posters;
            }

            List<Object> response = new List<object>();

            foreach (Poster p in result)
            {
                System.Console.WriteLine("Adding Poster to response");
                response.Add(p.ToJSON());
            }
            System.Console.WriteLine($"Posters in response: {response.Count()}");
            return response;
        }

        // PUT request
        public async Task<Poster> UpdatePoster(int id, Poster poster)
        {
            Poster p = await GetPoster(id);
            p.Name = poster.Name;
            p.ImageUrl = poster.ImageUrl;


            await _context.SaveChangesAsync();

            return p;
        }

        public async Task<Object> UpdatePosterJSON(int id, Poster poster)
        {
            Poster p = await UpdatePoster(id, poster);

            return p.ToJSON();
        }
    }
}