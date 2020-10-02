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
    public class CategoryController : ControllerBase
    {
        private readonly ISearchLogic searchLogic;
        public CategoryController(ISearchLogic searchLogic)
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