using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Filters;
using LogicInterface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;

namespace WebApplication.Controllers
{
    [ApiController]
    [Route("/tpoints")]
    public class TPointController : ControllerBase
    {
        private ISearchLogic searchLogic;
        private IAdminLogic adminLogic;

        public TPointController(ISearchLogic searchLogic, IAdminLogic adminLogic)
        {
            this.searchLogic = searchLogic;
            this.adminLogic = adminLogic;
        }
        
        // GET: /tpoints
        [HttpGet]
        public IActionResult GetAllTPoints()
        {
            return Ok(searchLogic.GetAllTPoints());
        }

        ///tpoints/filter?regionId=3&categories=2&categories=3 --> filter by reg & cats
        ///tpoints/filter?regionId=3 --> filter by reg
        [HttpGet("filter")]
        public IActionResult GetTPointsByRegionCat([FromQuery] int regionId, [FromQuery] int[] categories)
        {
            try
            {
                IEnumerable<TouristicPoint> touristicPoints;

                if (categories != null && categories.Length > 0)
                {
                    touristicPoints = searchLogic.FindByRegionCat(regionId, categories);
                }
                else
                {
                    touristicPoints = searchLogic.GetTPointsByRegion(regionId);
                }
                if (touristicPoints != null)
                {
                    return Ok(touristicPoints);
                }
                else
                {
                    return NotFound("No se encontraron puntos turisticos para la region " + regionId + " con las categorias seleccionadas");
                }
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST: /tpoints
        [HttpPost]
        [ServiceFilter(typeof(AuthorizationFilter))]
        public IActionResult Post([FromHeader] string token, [FromBody] TouristicPointModel tpModel)
        {
            try
            {
                TouristicPoint newTP = adminLogic.AddTouristicPoint(tpModel.ToEntity(),tpModel.RegionId, tpModel.Categories);
                return Ok(newTP);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


    }
}
