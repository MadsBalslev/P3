using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.Models;
using server.Services;

namespace server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InstitutionsController : ControllerBase
    {
        // private readonly databaseContext _context;

        private InstitutionService _institutionService;

        public InstitutionsController(databaseContext context)
        {
            _institutionService = new InstitutionService(context);
        }

        [HttpGet]
        public IEnumerable<Object> Get()
        {
            return _institutionService.GetAllInstitutionsJSON();
        }

        [HttpGet("{id:int}")]
        public ActionResult<Object> GetInstitutionDetails(int id)
        {
            try
            {
                 Object institution = _institutionService.GetInstitutionJSON(id);
                 return institution;
            }
            catch (System.Exception)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult<Institution> Post([FromBody] Institution institution)
        {
            try
            {
                Institution i = _institutionService.CreateInstitution(institution);
                return _institutionService.GetInstitution(i.Id);
            }
            catch (System.Exception)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id:int}")]
        public ActionResult<Object> Delete(int id)
        {
            try
            {
                Object i = _institutionService.GetInstitutionJSON(id);
                _institutionService.DeleteInstitution(id);
                return i;
            }
            catch (System.Exception)
            {
                return NotFound();
            }
        }
    }
}