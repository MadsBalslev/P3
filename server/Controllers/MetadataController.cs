using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.Entities;
using server.Services;

namespace server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MetadataController : ControllerBase
    {
        private MetadataService _metaDataService;
        public MetadataController(databaseContext context)
        {
            _metaDataService = new MetadataService(context);
        }

        [HttpGet("{id:int}")]
        public ActionResult<Object> GetTimerValue(int id)
        {
            try
            {
                return _metaDataService.GetTimerJSON(id);
            }
            catch (System.Exception)
            {

                return NotFound();
            }
        }

        //PUT request for timer
        [HttpPut("{id:int}")]
        public ActionResult<Object> PutTimerValue([FromBody] Metadata md, int id) => _metaDataService.UpdateTimerJSON(id, md);
    }
}