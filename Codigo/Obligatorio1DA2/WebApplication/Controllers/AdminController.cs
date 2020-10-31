using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Filters;
using LogicInterface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace WebApplication.Controllers
{
    [Route("/admins")]
    [ApiController]
    public class AdminController : Controller
    {
        private readonly IAdminLogic adminLogic;
        public AdminController(IAdminLogic adminLogic)
        {
            this.adminLogic = adminLogic;
        }

        
        // POST: /admins
        [HttpPost]
        [ServiceFilter(typeof(AuthorizationFilter))]
        public IActionResult Post([FromHeader] string token, [FromBody] Administrator admin)
        {
            try
            {
                Administrator newAdministrator = adminLogic.AddAdmin(admin);
                return Ok(newAdministrator);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //PUT: /admins
        [HttpPut]
        [ServiceFilter(typeof(AuthorizationFilter))]
        public IActionResult Put([FromHeader] string token, [FromBody] Administrator admin)
        {
            try
            {
                adminLogic.ModifyAdmin(admin);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //DELETE: /admins/1
        [HttpDelete("{adminId}")]
        [ServiceFilter(typeof(AuthorizationFilter))]
        public IActionResult Delete([FromHeader] string token, int adminId)
        {
            try
            {
                adminLogic.RemoveAdmin(adminId);
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

    }
}
