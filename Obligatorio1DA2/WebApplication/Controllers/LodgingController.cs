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
        private readonly ISearchLogic searchLogic;
        private readonly ILodgingLogic lodgingLogic;
        private readonly IAdminLogic adminLogic;

        public LodgingController(ISearchLogic searchLogic, ILodgingLogic lodgingLogic, IAdminLogic adminLogic)
        {
            this.searchLogic = searchLogic;
            this.lodgingLogic = lodgingLogic;
            this.adminLogic = adminLogic;
        }

        // GET: /lodgings
        [HttpGet]
        public IActionResult GetLodgingsByTP([FromBody] LodgingSearchModel search)
        {
            IEnumerable<LodgingSearchResultModel> touristicPoints = lodgingLogic.SearchLodgings(search);
            return Ok(touristicPoints);
        }

        // POST: /lodgings
        [HttpPost]
        public IActionResult Post([FromBody] LodgingModel lodgingModel)
        {
            try
            {
                Lodging newLodging = adminLogic.AddLodging(lodgingModel.ToEntity(), lodgingModel.TPointId);
                if (newLodging != null)
                {
                    return Ok(newLodging);
                }
                else
                {
                    return StatusCode(409, "Ya existe un hospedaje con este nombre en el punto turistico");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{lodgingId}")]
        public IActionResult Delete(int lodgingId)
        {
            adminLogic.RemoveLodging(lodgingId);
            return Ok();
        }
        
        [HttpPut]
        public IActionResult Put([FromBody] LodgingModel lodgingModel)
        {
            try
            {
                adminLogic.ModifyLodgingCapacity(lodgingModel.Id, lodgingModel.IsFull);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}