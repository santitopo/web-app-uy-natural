using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogicInterface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{

    [ApiController]
    [Route("/regions")]
    public class RegionsController : ControllerBase
    {
        private readonly ISearchLogic searchLogic;
        public RegionsController(ISearchLogic searchLogic)
        {
            this.searchLogic = searchLogic;
        }


        // GET: api/regions
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(searchLogic.GetAllRegions());
        }
    }
}
