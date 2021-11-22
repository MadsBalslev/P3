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

//         [HttpPost]

//         [HttpDelete]

//         [HttpPut]
//     }

// }