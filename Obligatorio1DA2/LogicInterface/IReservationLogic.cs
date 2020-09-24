using Domain;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicInterface
{
    public interface IReservationLogic
    {
        //PRE: There was a previous search
        //POS: Returns the bill with a unique code, contact number and info text
        BillModel ReserveLodging(LodgingSearchModel search, int lodgingId);
    }
}
