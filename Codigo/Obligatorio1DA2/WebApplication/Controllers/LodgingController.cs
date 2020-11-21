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
    [Route("/lodgings")]
    [ApiController]
    public class LodgingController : ControllerBase
    {
        private readonly ILodgingLogic lodgingLogic;
        private readonly IAdminLogic adminLogic;

        public LodgingController(ILodgingLogic lodgingLogic, IAdminLogic adminLogic)
        {
            this.lodgingLogic = lodgingLogic;
            this.adminLogic = adminLogic;
        }

        //localhost:44371/lodgings/filter?TPointId=1&Checkin=12102019&Checkout=14102019&AdultsNum=2&ChildsNum=2&BabiesNum=4
        //localhost:44371/lodgings/filter?TPointId=1&Checkin=12102019&Checkout=14102019&RetiredNum=2&AdultsNum=2&ChildsNum=2&BabiesNum=4
        [HttpGet("filter")]
        public IActionResult GetLodgingsByTP([FromQuery] LodgingSearchModel search)
        {
            IEnumerable<LodgingSearchResultModel> touristicPoints = lodgingLogic.SearchLodgings(search);
            return Ok(touristicPoints);
        }

        //https://localhost:44371/lodgings?LodgingName=hola&TpointId=2
        [HttpGet]
        public IActionResult GetbySimilarNameandTP([FromQuery] LodgingSelectionModel search)
        {
            try
            {
                IEnumerable<Lodging> lodgingList = lodgingLogic.SearchBySimilarNameandTpoint(search.LodgingName, search.TpointId);
                return Ok(lodgingList);
            }
            catch (Exception e)
            {
                return NotFound("Error de procesamiento");
            }

        }

        // POST: /lodgings
        [HttpPost]
        [ServiceFilter(typeof(AuthorizationFilter))]
        public IActionResult Post([FromHeader] string token, [FromBody] LodgingModel lodgingModel)
        {
            try
            {
                Lodging newLodging = adminLogic.AddLodging(lodgingModel.ToEntity(), lodgingModel.TPointId);
                return Ok(newLodging);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST: /lodgings/1
        [HttpDelete("{lodgingId}")]
        [ServiceFilter(typeof(AuthorizationFilter))]
        public IActionResult Delete([FromHeader] string token, int lodgingId)
        {
            try
            {
                adminLogic.RemoveLodging(lodgingId);
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }

        }

        // PUT: /lodgings
        [HttpPut]
        [ServiceFilter(typeof(AuthorizationFilter))]
        public IActionResult Put([FromHeader] string token, [FromBody] LodgingModel lodgingModel)
        {
            try
            {
                adminLogic.ModifyLodgingCapacity(lodgingModel.Id, lodgingModel.IsFull);
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

    }
}