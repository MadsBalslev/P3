// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Http;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;
// using server.Entities;
// using server.Services;

// namespace server.Controllers
// {

<<<<<<< HEAD:server/Controllers/ScheduleController.cs
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
=======
//     [ApiController]
//     [Route("[controller]")]
//     public class PosterScheduleController : ControllerBase
//     {

//         PosterScheduleService _posterscheduleService;

//         public PosterScheduleController(databaseContext context)
//         {
//             _psterscheduleService = new PosterScheduleService(context);
//         }

//         [HttpGet]
//         public IEnumerable<Object> Get()
//         {
//             // deez nuts
//         }
>>>>>>> 0e44ef67065fe2ce39983e68cc9fff866192339c:server/Controllers/PosterScheduleController.cs

//         [HttpPost]

//         [HttpDelete]

//         [HttpPut]
//     }

// }