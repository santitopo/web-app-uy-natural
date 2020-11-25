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
        private readonly IReservationLogic reservationLogic;

        public ReviewController(ILodgingLogic lodgingLogic, IReservationLogic reservationLogic)
        {
            this.lodgingLogic = lodgingLogic;
            this.reservationLogic = reservationLogic;
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

        [HttpGet("{reservationCode}")]
        public IActionResult GetReviewByReservationCode(string reservationCode)
        {
            try
            {
                return Ok(reservationLogic.ReviewExistsbyGuid(reservationCode));
            }
            catch (Exception)
            {
                return BadRequest("Error procesando la solicitud");
            }
        }

        // GET: /reviews/lodging
        [HttpGet("lodging/{lodgingId}")]
        public IActionResult GetReviewsByLodging(int lodgingId)
        {
            try
            {
                return Ok(reservationLogic.ReviewsByLodging(lodgingId));
            }
            catch (Exception)
            {
                return BadRequest("Error procesando la solicitud");
            }
        }
    }
}
