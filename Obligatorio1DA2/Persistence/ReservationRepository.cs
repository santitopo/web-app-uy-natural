using Domain;
using Microsoft.EntityFrameworkCore;
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
        private readonly DbContext context;

        public ReservationRepository(DbContext context) : base(context)
        {
            this.reservationDbSet = context.Set<Reservation>();
            this.stateDbSet = context.Set<State>();
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
    }
}

