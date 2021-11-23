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
    public class ScreensController : ControllerBase
    {
        ScreenService _screenService;

        public ScreensController(databaseContext context)
        {
            _screenService = new ScreenService(context);
        }

        [HttpGet]
        public async Task<IEnumerable<Object>> Get() => await _screenService.GetAllScreensJSON();

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Object>> GetScreenDetails(int id)
        {
            try
            {
                Object screen = await _screenService.GetScreenJSON(id);
                return screen;
            }
            catch (System.NullReferenceException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<ActionResult<Object>> Post([FromBody] Screen screen)
        {
            try
            {
                Screen s = await _screenService.CreateScreen(screen);
                return await _screenService.GetScreenJSON(s.Id);
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
                Object s = await _screenService.GetScreenJSON(id);
                await _screenService.DeleteScreen(id);
                return s;
            }
            catch (System.Exception)
            {
                return NotFound();
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Object>> Put([FromBody] Screen s, int id) => await _screenService.UpdateScreenJSON(id, s);
    }
}