using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
// using Newtonsoft.Json;
using System.Text.Json;
using server.Entities;
using server.Services;
using server.Models;

namespace server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private LoginService _loginService;
        public LoginController(databaseContext context)
        {
            _loginService = new LoginService(context);
        }

        [HttpPost]
        public ActionResult<string> Login([FromBody] LoginObject body)
        {
            try
            {
                string AuthString = _loginService.Login(body.Email, body.Password);
                Object AuthObject = new { password = AuthString };
                return JsonSerializer.Serialize(AuthString);
            }
            catch (System.Exception)
            {
                return Unauthorized();
            }
        }
    }
}