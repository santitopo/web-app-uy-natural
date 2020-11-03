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
    [Route("/reviews")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly ILodgingLogic lodgingLogic;

        public ReviewController(ILodgingLogic lodgingLogic)
        {
            this.lodgingLogic = lodgingLogic;
        }

        // POST: /reviews
        [HttpPost]
        public IActionResult Post([FromBody] ReviewModel reviewModel)
        {
            try
            {
                Review newReview = lodgingLogic.AddReview(reviewModel.ReservationCode, reviewModel.Description, reviewModel.Score);
                return Ok(newReview);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
