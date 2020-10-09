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

        // POST: /reservations
        [HttpPost]
        public IActionResult Post([FromBody] ReservationModel reservationData)
        {
            try
            {
                BillModel bill = reservationLogic.BookLodging(reservationData);
                return Ok(bill);
            }

            catch (InvalidOperationException e)
            {
                return BadRequest(e.Message);
            }
            catch (SystemException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return BadRequest("Error inesperado procesando la reserva");
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] ReservationUpdateModel reservationModel)
        {
            try
            {
                adminLogic.ModifyReservationState(reservationModel);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{reservationCode}")]
        public IActionResult Get(string reservationCode)
        {
            try
            {
                Reservation reservation = reservationLogic.GetReservationByGuid(reservationCode);
                StateModel statemodel = new StateModel()
                {
                    Description = reservation.StateDescription,
                    Name = reservation.State.Name,
                };


                if (reservation != null)
                {
                    return Ok(statemodel);
                }
                else
                {
                    return BadRequest("La reserva no existe");
                }
            }
            catch (Exception e)
            {
                return BadRequest("Error procesando la solicitud");
            }
        }

    }
}
