using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogicInterface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    [Route("/categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ISearchLogic searchLogic;
        public CategoriesController(ISearchLogic searchLogic)
        {
            this.searchLogic = searchLogic;
        }


        // GET: /categories
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(searchLogic.GetAllCategories());
        }
    }
}