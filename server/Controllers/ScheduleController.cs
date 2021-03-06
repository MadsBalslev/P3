using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.Entities;
using server.Services;

namespace server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ScheduleController : ControllerBase
    {

        private ScheduleService _scheduleService;

        public ScheduleController(databaseContext context)
        {
            _scheduleService = new ScheduleService(context);
        }

        [HttpGet]
        public async Task<IEnumerable<Object>> Get()
        {
            return await _scheduleService.GetAllSchedulesJSON();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Object>> GetScheduleDetails(int id)
        {
            try
            {
                return await _scheduleService.GetScheduleJSON(id);
            }
            catch (System.Exception)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<ActionResult<Object>> Post([FromBody] Schedule schedule)
        {
            try
            {
                Schedule s = await _scheduleService.CreateSchedule(schedule);
                return await _scheduleService.GetScheduleJSON(s.Id);
            }
            catch (System.Exception)
            {
                return NotFound("HEHE");
            }
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Object>> Delete(int id)
        {
            try
            {
                Object s = await _scheduleService.GetScheduleJSON(id);
                await _scheduleService.DeleteSchedule(id);
                return s;
            }
            catch (System.Exception)
            {
                return NotFound();
            }
        }


        [HttpPut("{id:int}")]
        public async Task<ActionResult<Object>> Put([FromBody] Schedule s, int id)
        {
            try
            {
                return await _scheduleService.UpdateScheduleJSON(id, s);
            }
            catch (System.Exception)
            {
                return NotFound();
            }
        }

        [HttpGet("/Schedule/Active/{poster_id:int}")]
        public async Task<IEnumerable<Object>> GetActive(int poster_id)
        {
            try
            {
                return await _scheduleService.GetActiveSchedulesJSON(poster_id);
            }
            catch (System.Exception)
            {
                throw new Exception();
            }
        }
    }

}