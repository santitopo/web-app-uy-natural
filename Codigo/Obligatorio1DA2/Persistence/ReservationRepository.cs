using Domain;
using Microsoft.EntityFrameworkCore;
using Models;
using PersistenceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Persistence
{
    public class ReservationRepository : Repository<Reservation>, IReservationRepository
    {
        private readonly DbSet<Reservation> reservationDbSet;
        private readonly DbSet<State> stateDbSet;
        private readonly DbSet<Lodging> DbSet;
        private readonly DbContext context;

        public ReservationRepository(DbContext context) : base(context)
        {
            this.reservationDbSet = context.Set<Reservation>();
            this.stateDbSet = context.Set<State>();
            this.DbSet = context.Set<Lodging>();
            this.context = context;
        }

        public bool Exists(Guid code)
        {
            Reservation reservation = reservationDbSet.Where(x => x.Code.Equals(code)).FirstOrDefault();
            return reservation != null;
        }

        public Reservation FindByCode(Guid code)
        {
            Reservation reservation = reservationDbSet.Include(x => x.State).Where(x => x.Code.Equals(code)).FirstOrDefault();
            return reservation;
        }

        public State GetDefaultState()
        {
            State defaultState = stateDbSet.Where(x => x.Name == Constants.DEFAULT_RESERVATION_STATE).FirstOrDefault();
            if (defaultState == null)
            {
                defaultState = new State()
                {
                    Name = Constants.DEFAULT_RESERVATION_STATE
                };
                stateDbSet.Add(defaultState);
                context.SaveChanges();
            }
            return defaultState;
        }

        public List<ReservationReportResultModel> GetReportByTPoint(int tpointId, DateTime fromDate, DateTime toDate)
        {
            //Get all Lodgings of selected TPoint
            IEnumerable<Lodging> lodgings = DbSet
                .Include(x => x.TouristicPoint)
                .Where(x => x.TouristicPoint.Id == tpointId && !x.IsDeleted);

            List<ReservationReportResultModel> reportResult = new List<ReservationReportResultModel>();
            foreach (Lodging l in lodgings)
            {
                IEnumerable<Reservation> reservationsOfLodging = reservationDbSet
                    .Include(x => x.Lodging)
                    .Include(x => x.State)
                    .Where(x => x.Lodging.Id == l.Id && 
                            ( (x.CheckIn >= fromDate && x.CheckIn <= toDate) 
                            || (x.CheckOut >= fromDate && x.CheckOut <= toDate)
                            || (x.CheckIn <= fromDate && x.CheckOut >= toDate)));
                if (reservationsOfLodging.Count() > 0)
                {
                    ReservationReportResultModel result = new ReservationReportResultModel()
                    {
                        lodging = l,
                        Reservations = reservationsOfLodging.Count(),
                    };
                    reportResult.Add(result);
                }
            }
            //Orders by number of reservations and as a second criteria by earlier addedDates.
           // reportResult.OrderByDescending(x => x.Reservations).ThenBy(x => x.lodging.CreatedDate);

            reportResult.Sort((x, y) =>
            {
                int result = y.Reservations.CompareTo(x.Reservations);
                return result != 0 ? result : x.lodging.CreatedDate.CompareTo(y.lodging.CreatedDate);
            });
            return reportResult;
        }
    }
}

