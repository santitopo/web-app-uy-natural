using Domain;
using System;
using System.Collections.Generic;
using System.Text;
using Models;

namespace PersistenceInterface
{
    public interface IReservationRepository : IRepository<Reservation>
    {
        bool Exists(Guid code);
        Reservation FindByCode(Guid code);
        State GetDefaultState();
        List<ReservationReportResultModel> GetReportByTPoint(int tpointId, DateTime fromDate, DateTime toDate);
    }
}
