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

        //localhost:44371/lodgings?LodgingName=hola&TpointId=2
        private IActionResult GetLodgingsByTP([FromQuery] LodgingSearchModel search)
        {
            IEnumerable<LodgingSearchResultModel> touristicPoints = lodgingLogic.SearchLodgings(search);
            return Ok(touristicPoints);
        }

        //localhost:44371/lodgings?TPointId=1&Checkin=12102019&Checkout=14102019&RetiredNum=2&AdultsNum=2&ChildsNum=2&BabiesNum=4
        private IActionResult GetbySimilarNameandTP([FromQuery] LodgingSelectionModel search)
        {

            IEnumerable<Lodging> lodgingList = lodgingLogic.SearchBySimilarNameandTpoint(search.LodgingName, search.TpointId);
            return Ok(lodgingList);

        }

        [HttpGet]
        public IActionResult Get([FromQuery] LodgingSelectionModel searchSimilar, [FromQuery] LodgingSearchModel searchbyTP)
        {
            try
            {
                if (searchSimilar!= null && searchSimilar.LodgingName != null)
                {

                    return GetbySimilarNameandTP(searchSimilar);
                }
                else if (searchbyTP != null && searchbyTP.Checkin != null && searchbyTP.Checkout != null)
                {
                    return GetLodgingsByTP(searchbyTP);
                }

                return Ok();
            }
            catch (Exception e)
            {
                return NotFound("Error de procesamiento");
            }
        }

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

        [HttpPut]
        [ServiceFilter(typeof(AuthorizationFilter))]
        public IActionResult Put([FromBody] LodgingModel lodgingModel)
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