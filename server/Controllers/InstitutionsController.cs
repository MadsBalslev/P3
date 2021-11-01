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
        public IEnumerable<Institution> Get()
        {
            return _institutionService.GetAllInstitutions();
        }

        [HttpGet("{id:int}")]
        public ActionResult<Institution> GetInstitutionDetails(int id)
        {
            try
            {
                 Institution institution = _institutionService.GetInstitution(id);
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
            return _institutionService.CreateInstitution(institution);
        }

        [HttpDelete("{id:int}")]
        public ActionResult<Institution> Delete(int id)
        {
            return _institutionService.DeleteInstitution(id);
        }
    }
}