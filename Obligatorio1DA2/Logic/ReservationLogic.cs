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
        private IReservationRepository reservationRepository;
        private IUserRepository adminRepository;
        private ILodgingRepository lodgingRepository;
        private IPriceCalculator priceCalculator;
        private IRepository<Client> clientRepository;

        public ReservationLogic(IReservationRepository reservationRepository, IUserRepository adminRepository,
            ILodgingRepository lodgingRepository, IPriceCalculator priceCalculator, IRepository<Client> clientRepository)
        {
            this.reservationRepository = reservationRepository;
            this.adminRepository = adminRepository;
            this.lodgingRepository = lodgingRepository;
            this.priceCalculator = priceCalculator;
            this.clientRepository = clientRepository;
        }

        public BillModel BookLodging(ReservationModel reservationData)
        {
            // Verify exists and available
            Lodging wantedLodging = lodgingRepository.Get(reservationData.LodgingId);
            if (wantedLodging == null) { throw new InvalidOperationException("El hospedaje no existe"); }
            if (!wantedLodging.Capacity) { throw new InvalidOperationException("El hospedaje no tiene capacidad disponible"); }
            else
            {
                // Calculate price
                double price = priceCalculator.CalculatePrice(reservationData, wantedLodging.Price);

                //Look up for client and create if doesnt exist
                Client client = adminRepository.GetClientbyAttributes(reservationData.Mail, reservationData.Name, reservationData.Surname);
                if (client == null)
                {
                    client = new Client()
                    {
                        Mail = reservationData.Mail,
                        Name = reservationData.Name,
                        Surname = reservationData.Surname
                    };
                    clientRepository.Create(client);
                    clientRepository.Save();
                }

                // Create reservation object
                Guid code = createUnusedGuid();
                Reservation newReservation = new Reservation()
                {
                    CheckIn = DateTime.ParseExact(reservationData.Checkin, "ddMMyyyy", null),
                    CheckOut = DateTime.ParseExact(reservationData.Checkout, "ddMMyyyy", null),
                    Client = client,
                    Code = code,
                    Lodging = wantedLodging,
                    State = reservationRepository.GetDefaultState(),
                    StateDescription = Constants.DEFAULT_RESERVATION_STATE,
                    Price = price
                };

                reservationRepository.Create(newReservation);
                reservationRepository.Save();

                // Create Bill and return
                BillModel bill = new BillModel
                {
                    ReservationCode = code,
                    PricePaid = price,
                    Phone = wantedLodging.Phone,
                    Description = wantedLodging.Description
                };

                return bill;
            }
            
        }

        public Reservation GetReservationByGuid(string code)
        {
            Guid guidcode = new Guid(code);
            Reservation reservation = reservationRepository.FindbyCode(guidcode);
            return reservation;
            
        }

        private Guid createUnusedGuid()
        {
            int counter = 0;
            Guid code = Guid.NewGuid();
            while (reservationRepository.Exists(code) && counter < 10)
            {
                code = new Guid();
                counter++;
            }
            if (counter == 10) { throw new SystemException("No se pudo asignar un código único a la reserva"); }
            else
            {
                return code;
            }
        }


    }
}
