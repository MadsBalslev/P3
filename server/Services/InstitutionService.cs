using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using server.Entities;

namespace server.Services
{
    public class InstitutionService
    {
        public InstitutionService(databaseContext context)
        {
            _context = context;
        }

        private databaseContext _context;

        public async Task<IEnumerable<Institution>> GetAllInstitutions()
        {
            IEnumerable<Institution> insts = await _context.Institutions
            .Include(i => i.AdminNavigation)
            .ToListAsync();

            return insts;
        }

        public async Task<Institution> GetInstitution(int id)
        {
            Institution institution = await _context.Institutions
                .Include(i => i.AdminNavigation)
                .Where(i => i.Id == id)
                .FirstOrDefaultAsync();

            if (institution == null)
            {
                throw new NullReferenceException("Institution was not found");
            }

            return institution;
        }
        public async Task<Institution> CreateInstitution(Institution institution)
        {
            await _context.Institutions.AddAsync(institution);
            await _context.SaveChangesAsync();

            Institution inst = await _context.Institutions
                .Include(i => i.AdminNavigation)
                .Where(i => i.Name == institution.Name)
                .FirstOrDefaultAsync();

            return inst;
        }
        public async Task<Institution> DeleteInstitution(int id)
        {
            Institution institution = await _context.Institutions.FindAsync(id);
            _context.Institutions.Remove(institution);
            await _context.SaveChangesAsync();

            return institution;
        }

        // PUT request
        public async Task<Institution> UpdateInstitution(int id, Institution institution)
        {
            Institution inst = await GetInstitution(id);
            inst.Name = institution.Name;
            inst.Admin = institution.Admin;


            await _context.SaveChangesAsync();

            return inst;
        }
    }
}