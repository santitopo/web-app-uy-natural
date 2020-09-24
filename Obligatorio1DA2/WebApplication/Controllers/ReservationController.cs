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

        public ReservationController(IReservationLogic reservationLogic)
        {
            this.reservationLogic = reservationLogic;
        }

        // POST: /reservation
        [HttpPost]
        public IActionResult Post([FromBody] LodgingSearchModel search, Client client)
        {
            BillModel bill = reservationLogic.ReserveLodging(search, client);
            return Ok(bill);
        }

    }
}
