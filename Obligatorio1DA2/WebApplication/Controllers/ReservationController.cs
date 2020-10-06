using Domain;
using LogicInterface;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Controllers
{
    [ApiController]
    [Route("/reservations")]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationLogic reservationLogic;
        private readonly IAdminLogic adminLogic;

        public ReservationController(IReservationLogic reservationLogic, IAdminLogic adminLogic)
        {
            this.reservationLogic = reservationLogic;
            this.adminLogic = adminLogic;
        }

        // GET: /reservations
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(reservationLogic.GetAllReservations());
        }

        // GET: /reservations/states
        [HttpGet("states")]
        public IActionResult GetStates()
        {
            return Ok(reservationLogic.GetAllStates());
        }

        // POST: /reservation
        [HttpPost]
        public IActionResult Post([FromBody] LodgingSearchModel search, int lodgingId)
        {
            BillModel bill = reservationLogic.ReserveLodging(search, lodgingId);
            return Ok(bill);
        }

        [HttpPut]
        public IActionResult Put([FromBody] ReservationModel reservationModel)
        {
            try
            {
                adminLogic.ModifyReservationState(reservationModel.StateId, reservationModel.Id, reservationModel.StateDescription);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
