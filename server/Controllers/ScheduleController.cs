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
    public class ScheduleController : ControllerBase
    {

        ScheduleService _scheduleService;

        public ScheduleController(databaseContext context)
        {
            _scheduleService = new ScheduleService(context);
        }

        [HttpGet]
        public IEnumerable<Object> Get()
        {

        }

        [HttpPost]

        [HttpDelete]

        [HttpPut]
    }

}