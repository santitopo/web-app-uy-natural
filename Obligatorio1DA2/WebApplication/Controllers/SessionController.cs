using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LogicInterface;
using Models;

namespace WebApplication.Controllers
{
    [ApiController]
    [Route("/sessions")]
    public class SessionController : ControllerBase
    {
        private readonly ISessionLogic logic;

        public SessionController(ISessionLogic logic)
        {
            this.logic = logic;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel loginModel)
        {
            try
            {
                return Ok(logic.LogIn(loginModel.Mail, loginModel.Password));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete("logout")]
        public IActionResult Logout([FromHeader] string token)
        {
            try
            {
                logic.LogOut(token);
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
