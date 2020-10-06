using System;
using System.Collections.Generic;
using System.Text;
using Domain;
using LogicInterface;
using Models;
using PersistenceInterface;

namespace Logic
{
    public class ReservationLogic : IReservationLogic
    {
        private readonly IRepository<State> stateRepository;
        private readonly IRepository<Reservation> reservationRepository;

        public ReservationLogic(IRepository<Reservation> reservationRepository, IRepository<State> stateRepository)
        {
            this.reservationRepository = reservationRepository;
            this.stateRepository = stateRepository;
        }

        public IEnumerable<Reservation> GetAllReservations()
        {
            string[] param = { };
            return reservationRepository.GetAll(param);
        }

        public IEnumerable<State> GetAllStates()
        {
            string[] param = { };
            return stateRepository.GetAll(param);
        }

        public BillModel ReserveLodging(LodgingSearchModel search, int lodgingId)
        {
            throw new NotImplementedException();
        }

    }
}
