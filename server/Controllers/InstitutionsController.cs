using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using server.Entities;
using server.Services;

namespace server.Controllers
{
    [Authorize]
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
        public async Task<IEnumerable<Object>> Get()
        {
            return await _institutionService.GetAllInstitutionsJSON();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Object>> GetInstitutionDetails(int id)
        {
            try
            {
                return await _institutionService.GetInstitutionJSON(id);
            }
            catch (System.Exception)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<ActionResult<Object>> Post([FromBody] Institution institution)
        {
            try
            {
                Institution i = await _institutionService.CreateInstitution(institution);
                return _institutionService.GetInstitutionJSON(i.Id);
            }
            catch (System.Exception)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Object>> Delete(int id)
        {
            try
            {
                Object i = await _institutionService.GetInstitutionJSON(id);
                await _institutionService.DeleteInstitution(id);
                return i;
            }
            catch (System.Exception)
            {
                return NotFound();
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Object>> Put([FromBody] Institution i, int id) => await _institutionService.UpdateInstitutionJSON(id, i);
    }
}