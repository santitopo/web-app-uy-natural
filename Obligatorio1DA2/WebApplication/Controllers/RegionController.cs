using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using LogicInterface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{

    [ApiController]
    [Route("/regions")]
    public class RegionController : ControllerBase
    {
        private readonly ISearchLogic searchLogic;
        public RegionController(ISearchLogic searchLogic)
        {
            this.searchLogic = searchLogic;
        }

        // GET: /regions
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(searchLogic.GetAllRegions());
        }


    }
}
