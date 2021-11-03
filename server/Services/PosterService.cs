using System;
using System.Collections.Generic;
using System.Linq;
using server.Models;
namespace server.Services
{
    public class PosterService
    {
        public PosterService(databaseContext context)
        {
            _context = context;
        }

        private databaseContext _context;

        public IEnumerable<Poster> GetAllPosters() 
        {
            System.Console.WriteLine("Fetching posters");
            return _context.Posters.ToList();
        }
        public IEnumerable<Object> GetAllPosterJSON()
        {
            IEnumerable<Poster> posters = GetAllPosters();
            List<Object> response = new List<Object>();

            System.Console.WriteLine("Formatting as JSON");

            foreach (Poster p in posters)
            {
                System.Console.WriteLine(p.ToJSON());
                response.Add(p.ToJSON());
            }

            return response;
        }
        public Poster GetPoster(int id)
        {
            Poster poster = _context.Posters.Find(id);

            if (poster == null)
            {
                throw new NullReferenceException("Poster was not found");
            }

            return poster;
        }

        public Object GetPosterJSON(int id)
        {
            Poster p = GetPoster(id);
            return p.ToJSON();
        }

        public Poster CreatePoster(Poster poster)
        {
            _context.Posters.Add(poster);
            _context.SaveChanges();

            return _context.Posters.Where(p => p.Name == poster.Name && p.CreatedBy == poster.CreatedBy).FirstOrDefault();
        }

        public Poster DeletePoster(int id)
        {
            Poster poster = _context.Posters.Find(id);
            _context.Posters.Remove(poster);
            _context.SaveChanges();

            return poster;
        }


        // PUT request
        public Poster UpdatePoster(int id, Poster poster)
        {
            Poster p = GetPoster(id);
            p.Name = poster.Name;
            p.StartDate = poster.StartDate;
            p.EndDate = poster.EndDate;
            p.ImageUrl = poster.ImageUrl;


            _context.SaveChanges();

            return p;
        }

        public Object UpdatePosterJSON(int id, Poster p) => UpdatePoster(id, p).ToJSON();
    }
}