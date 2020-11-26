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
        
        [HttpGet]
        private IActionResult GetAllTPoints()
        {
            try
            {
                return Ok(searchLogic.GetAllTPoints());
            }
            catch (NotImplementedException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception)
            {
                return BadRequest("Error Desconocido");
            }
        }

        ///tpoints?regionId=3&categories=2&categories=3 --> filter by reg OR by reg & cats
        private IActionResult GetTPointsByRegionCat([FromQuery] int regionId, [FromQuery] int[] categories)
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

        [HttpGet]
        public IActionResult Get([FromQuery] int regionId, [FromQuery] int[] categories)
        {
            try
            {
                if (regionId != 0)
                {
                    return GetTPointsByRegionCat(regionId, categories);
                }
                else
                {
                    return GetAllTPoints();
                }
            }
            catch (Exception)
            {
                return BadRequest("Error Desconocido");
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(AuthorizationFilter))]
        public IActionResult Post([FromHeader] string token, [FromBody] TouristicPointInsertModel tpModel)
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
