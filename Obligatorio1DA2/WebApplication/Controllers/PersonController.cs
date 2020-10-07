using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using LogicInterface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace WebApplication.Controllers
{
    [Route("/persons")]
    [ApiController]
    public class PersonController : Controller
    {
        private readonly IAdminLogic adminLogic;
        public PersonController(IAdminLogic adminLogic)
        {
            this.adminLogic = adminLogic;
        }

        // POST: /lodgings
        [HttpPost]
        public IActionResult Post([FromBody] Administrator admin)
        {
            try
            {
                Administrator newAdministrator = adminLogic.AddAdmin(admin);
                if (newAdministrator != null)
                {
                    return Ok(newAdministrator);
                }
                else
                {
                    return StatusCode(409, "Ya existe un administrador con el mismo mail");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST: /lodgings
        [HttpPut]
        public IActionResult Put([FromBody] Administrator admin)
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

        [HttpDelete("{personId}")]
        public IActionResult Delete(int personId)
        {
            adminLogic.RemoveAdmin(personId);
            return Ok();
        }

    }
}
