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

        //localhost:44371/lodgings/filter?TPointId=1&Checkin=12102019&Checkout=14102019&AdultsNum=2&ChildsNum=2&BabiesNum=4
        [HttpGet("filter")]
        public IActionResult GetLodgingsByTP([FromQuery] LodgingSearchModel search)
        {
            IEnumerable<LodgingSearchResultModel> touristicPoints = lodgingLogic.SearchLodgings(search);
            return Ok(touristicPoints);
        }

    }
}