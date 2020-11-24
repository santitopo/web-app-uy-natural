using Domain;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicInterface
{
    public interface IReservationLogic
    {
        IEnumerable<Reservation> GetAllReservations();
        IEnumerable<State> GetAllStates();

        //PRE: There was a previous search
        //POS: Returns the bill with a unique code, contact number and info text
        BillModel BookLodging(ReservationModel reservationData);

        Reservation GetReservationByGuid(string code);

        IEnumerable<ReservationReportResultModel> GetReportByTPoint(ReservationReportRequestModel request);

        bool ReviewExistsbyGuid(string reservationCode);

        IEnumerable<Review> ReviewsByLodging(int lodgingId);

    }
}
