using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using LogicInterface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApplication.Controllers
{
    [ApiController]
    [Route("/tpoints")]
    public class TPointsController : ControllerBase
    {
        private ISearchLogic searchLogic;

        public TPointsController(ISearchLogic searchLogic)
        {
            this.searchLogic= searchLogic;
        }

        [HttpGet]
        
        public IActionResult GetAllTPoints()
        {
            ////delete this
            //int[] a = { 1, 2 };
            //IEnumerable<TouristicPoint> touristicPoints = searchLogic.FindByRegionCat(1, a);
            //return Ok(touristicPoints);
            ////      
            return Ok(searchLogic.GetAllTPoints());
        }

        ///tpoints/by-region?regionId=3
        [HttpGet("by-region")]
        public IActionResult GetTPointsByRegion([FromQuery] int regionId)
        {
            IEnumerable<TouristicPoint> touristicPoints = searchLogic.GetTPointsByRegion(regionId);

            if (touristicPoints != null) return Ok(touristicPoints);
            else return NotFound("No se encontraron puntos turisticos para la region " + regionId);
        }

        ///tpoints/by-region?regionId=3
        [HttpGet("by-region-cat")]
        public IActionResult FindTPointsByRegionCat([FromQuery] int regionId, [FromQuery] IEnumerable<int> categories)
        {
            IEnumerable<TouristicPoint> touristicPoints = searchLogic.FindByRegionCat(regionId, categories);

            if (touristicPoints != null) return Ok(touristicPoints);
            else return NotFound("No se encontraron puntos turisticos para la region " + regionId + " con las categorias seleccionadas");
        }




    }
}
