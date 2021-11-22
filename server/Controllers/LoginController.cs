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
        public ActionResult<string> Login([FromForm] string email, [FromForm] string password)
        {
            try
            {
                string AuthString = _loginService.Login(email, password);
                return AuthString;
            }
            catch (System.Exception)
            {
                return Unauthorized();
            }
        }
    }
}