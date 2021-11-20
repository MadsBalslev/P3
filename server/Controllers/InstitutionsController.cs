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
        public async Task<string> Get()
        {
            IEnumerable<Institution> insts = await _institutionService.GetAllInstitutions();
            return JsonConvert.SerializeObject(insts);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<string>> GetInstitutionDetails(int id)
        {
            try
            {
                Institution institution = await _institutionService.GetInstitution(id);
                return JsonConvert.SerializeObject(institution);
            }
            catch (System.Exception)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<ActionResult<string>> Post([FromBody] Institution institution)
        {
            try
            {
                Institution i = await _institutionService.CreateInstitution(institution);
                return JsonConvert.SerializeObject(i);
            }
            catch (System.Exception)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<string>> Delete(int id)
        {
            try
            {
                Institution i = await _institutionService.GetInstitution(id);
                await _institutionService.DeleteInstitution(id);
                return JsonConvert.SerializeObject(i);
            }
            catch (System.Exception)
            {
                return NotFound();
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<string>> Put([FromBody] Institution inst, int id)
        {
            Institution i = await _institutionService.UpdateInstitution(id, inst);
            return JsonConvert.SerializeObject(i);
        }
    }
}