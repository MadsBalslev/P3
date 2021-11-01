using System.Collections.Generic;
using System;
using System.Linq;
using server.Models;
namespace server.Services
{
    public class InstitutionService
    {
        public InstitutionService(databaseContext context)
        {
            _context = context;
        }

        private databaseContext _context;

        public IEnumerable<Institution> GetAllInstitutions()
        {
            return _context.Institutions.ToList();
        }

        public Institution GetInstitution(int id)
        {
            Institution institution = _context.Institutions.Find(id);

            if (institution == null)
            {
                throw new NullReferenceException("Institution was not found");
            }

            return institution;
        }

        public Institution CreateInstitution(Institution institution)
        {
            _context.Institutions.Add(institution);
            _context.SaveChanges();

            return _context.Institutions.Where(i => i.Name == institution.Name).FirstOrDefault();
        }

        public Institution DeleteInstitution(int id)
        {
            Institution institution = _context.Institutions.Find(id);
            _context.Institutions.Remove(institution);
            _context.SaveChanges();

            return institution;
        }
    }
}