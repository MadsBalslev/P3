using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.Models;

namespace server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InstitutionsController : ControllerBase
    {
        private readonly databaseContext _context;

        public InstitutionsController(databaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Institution> Get()
        {
            //await Task.Delay(3000);
            return _context.Institutions.ToList();
        }

        [HttpGet("{id:int}")]
        public ActionResult<Institution> GetInstitutionDetails(int id)
        {
            Institution institution = _context.Institutions.Where(i => i.Id == id).FirstOrDefault();

            if (institution == null)
            {
                return NotFound();
            }

            return institution;
        }

        [HttpPost]
        public ActionResult<Institution> Post([FromBody] Institution institution)
        {
            _context.Institutions.Add(institution);
            _context.SaveChanges();

            return _context.Institutions
            .Where(i => i.Name == institution.Name)
            .FirstOrDefault();
        }

        [HttpDelete("{id:int}")]
        public ActionResult<Institution> Delete(int id)
        {
            Institution institution = _context.Institutions.Find(id);
            _context.Institutions.Remove(institution);
            _context.SaveChanges();

            return institution;
        }
    }
}