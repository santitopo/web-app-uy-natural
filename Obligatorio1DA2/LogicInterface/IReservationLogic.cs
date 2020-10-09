using Domain;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicInterface
{
    public interface IReservationLogic
    {
        //PRE: There was a previous search. The client sends the information again with the lodgingId in the model
        //POS: Returns the bill with a unique code, contact number and info text
        BillModel BookLodging(ReservationModel reservationData);

        Reservation GetReservationByGuid(string code);
    }
}
