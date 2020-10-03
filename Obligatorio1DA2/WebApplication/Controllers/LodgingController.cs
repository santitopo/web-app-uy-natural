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
    [Route("/lodgings")]
    [ApiController]
    public class LodgingController : ControllerBase
    {
        private readonly ILodgingLogic lodgingLogic;

        public LodgingController(ILodgingLogic lodgingLogic)
        {
           this.lodgingLogic = lodgingLogic;
        }

        // POST: /lodgings
        [HttpPost]
        public IActionResult GetLodgingsByTP([FromBody] LodgingSearchModel search)
        {
            IEnumerable<LodgingSearchResultModel> touristicPoints = lodgingLogic.SearchLodgings(search);
            return Ok(touristicPoints);
        }

    }
}