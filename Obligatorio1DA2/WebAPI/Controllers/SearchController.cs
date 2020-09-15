using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using LogicInterface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SearchController : ControllerBase
    {
        private readonly ISearchController SearchLogic;

        private static readonly string[] Regions = new[]{
            "Metropolitana", "CentroSur", "Este", "Litoral Norte", "Corredor de Pajaros Pintados"
        };

        private static readonly string[] Categories = new[]{
            "Playas", "Ciudades", "Pueblos", "Areas Protegidas", "Otros"
        };

        [HttpGet]
        public IActionResult GetAllRegions()
        {
            return Ok(SearchLogic.GetAllRegions());
        }

        [HttpPost]
        public IActionResult GetTuristicPointsByRegion([FromBody] int regionId)
        {
            IEnumerable<TouristicPoints> touristicPoints = SearchLogic.GetTPointsByRegion(regionId);

            if (touristicPoints != null) return Ok(touristicPoints);
            else return NotFound("No se encontraron puntos turisticos para la region " + regionId);
        }

        [HttpPost]
        public IActionResult GetTuristicPointsByRegion([FromBody] int regionId, [FromBody] int category)
        {
            IEnumerable<TouristicPoints> touristicPoints = SearchLogic.GetTPointsByRegionCat(regionId, category);

            if (touristicPoints != null) return Ok(touristicPoints);
            else return NotFound("No se encontraron puntos turisticos para dicha categoria " + regionId);
        }
    }
}
