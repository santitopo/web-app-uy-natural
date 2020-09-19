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
    [Route("/searchs")]
    public class SearchsController : ControllerBase
    {
        private ISearchLogic searchLogic;

        private static readonly string[] Regions = new[]{
            "Metropolitana", "CentroSur", "Este", "Litoral Norte", "Corredor de Pajaros Pintados"
        };

        private static readonly string[] Categories = new[]{
            "Playas", "Ciudades", "Pueblos", "Areas Protegidas", "Otros"
        };

        public SearchsController(ISearchLogic searchLogic)
        {
            this.searchLogic= searchLogic;
        }

        [HttpGet]
        public IActionResult GetAllTPoints()
        {
            return Ok("hello");
        }

        [HttpPost]
        public IActionResult GetTuristicPointsByRegion([FromBody] int regionId)
        {
            IEnumerable<TouristicPoints> touristicPoints = searchLogic.GetTPointsByRegion(regionId);

            if (touristicPoints != null) return Ok(touristicPoints);
            else return NotFound("No se encontraron puntos turisticos para la region " + regionId);
        }
    }
}
