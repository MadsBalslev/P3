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
    public class ScreensController : ControllerBase
    {
        ScreenService _screenService;

        public ScreensController(databaseContext context)
        {
            _screenService = new ScreenService(context);
        }

        [HttpGet]
        public IEnumerable<Object> Get() => _screenService.GetAllScreensJSON();

        [HttpGet("{id:int}")]
        public ActionResult<Object> GetScreenDetails(int id)
        {
            try
            {
                Object screen = _screenService.GetScreenJSON(id);
                return screen;
            }
            catch (System.NullReferenceException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult<Object> Post([FromBody] Screen screen)
        {
            try
            {
                Screen s = _screenService.CreateScreen(screen);
                return _screenService.GetScreenJSON(s.Id);
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
                Object s = _screenService.GetScreenJSON(id);
                _screenService.DeleteScreen(id);
                return s;
            }
            catch (System.Exception)
            {
                return NotFound();
            }
        }

        [HttpPut("{id:int}")]
        public ActionResult<Object> Put([FromBody] Screen s, int id) => _screenService.UpdateScreenJSON(id, s);
    }
}