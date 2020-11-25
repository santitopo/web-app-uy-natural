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
        BillModel BookLodging(ReservationModel reservationData);
        Reservation GetReservationByGuid(string code);
        IEnumerable<ReservationReportResultModel> GetReportByTPoint(ReservationReportRequestModel request);
        bool ReviewExistsbyGuid(string reservationCode);
        IEnumerable<Review> ReviewsByLodging(int lodgingId);

    }
}
