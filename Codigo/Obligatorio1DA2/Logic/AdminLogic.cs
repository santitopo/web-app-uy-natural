using Domain;
using LogicInterface;
using Models;
using PersistenceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic
{
    public class AdminLogic : IAdminLogic
    {
        private readonly ITPointRepository tpRepository;
        private readonly IRepository<Region> regionRepository;
        private readonly IRepository<Category> categoryRepository;
        private readonly ILodgingRepository lodgingRepository;
        private readonly IRepository<Reservation> reservationRepository;
        private readonly IRepository<State> stateRepository;
        private readonly IAdminRepository userRepository;
        private readonly IRepository<Person> personRepository;

        public AdminLogic(ITPointRepository repository, IRepository<Region> regionRepository,
            IRepository<Category> categoryRepository, ILodgingRepository lodgingRepository,
            IRepository<Person> personRepository, IAdminRepository userRepository,
            IRepository<Reservation> reservationRepository, IRepository<State> stateRepository)
        {
            this.tpRepository = repository;
            this.regionRepository = regionRepository;
            this.categoryRepository = categoryRepository;
            this.lodgingRepository = lodgingRepository;
            this.userRepository = userRepository;
            this.personRepository = personRepository;
            this.reservationRepository = reservationRepository;
            this.stateRepository = stateRepository;
        }

        public IEnumerable<Administrator> GetAdmins()
        {
            string [] param = { };
            return userRepository.GetAll(param);
        }

        public Administrator AddAdmin(Administrator anAdmin)
        {
            if (userRepository.GetAdminByMail(anAdmin.Mail) == null)
            {
                userRepository.Create(anAdmin);
                userRepository.Save();
                return anAdmin;
            }
            else
            {
                throw new InvalidOperationException("Ya existe un administrador con ese mail");
            }
        }

        public Lodging AddLodging(Lodging aLodging, int touristicPointId)
        {
            if (!lodgingRepository.Exists(aLodging.Name, aLodging.Direction))
            {
                TouristicPoint tp = tpRepository.Get(touristicPointId);
                aLodging.TouristicPoint = tp;
                lodgingRepository.Create(aLodging);
                lodgingRepository.Save();

                return aLodging;
            }
            else
            {
                throw new InvalidOperationException("Ya existe un hospedaje con ese nombre y direccion");
            }
        }

        public TouristicPoint AddTouristicPoint(TouristicPoint aTouristicPoint, int regionId, int[] categories)
        {
            if (!tpRepository.Exists(aTouristicPoint.Name))
            {
                Region region = regionRepository.Get(regionId);
                aTouristicPoint.Region = region;
                tpRepository.Create(aTouristicPoint);
                tpRepository.Save();

                int newTouristicPointId = tpRepository.GetByName(aTouristicPoint.Name).Id;

                List<TouristicPointsCategory> tpcList = new List<TouristicPointsCategory>();

                for (int i = 0; i < categories.Length; i++)
                {
                    TouristicPointsCategory tpc = new TouristicPointsCategory()
                    {
                        Category = categoryRepository.Get(categories[i]),
                        CategoryId = categories[i],
                        TouristicPointId = newTouristicPointId,
                        TouristicPoint = aTouristicPoint
                    };
                    tpcList.Add(tpc);
                }

                aTouristicPoint.Categories = tpcList;
                tpRepository.Update(aTouristicPoint);
                tpRepository.Save();

                return aTouristicPoint;
            }
            else
            {
                throw new InvalidOperationException("Ya existe un punto turistico con ese nombre");
            }
        }

        public void ModifyLodgingCapacity(int lodgingId, bool isFull)
        {
            if (lodgingRepository.Get(lodgingId) != null)
            {
                Lodging lodging = lodgingRepository.Get(lodgingId);
                lodging.Capacity = !isFull;
                lodgingRepository.Update(lodging);
                lodgingRepository.Save();
            }
            else
            {
                throw new InvalidOperationException("El hospedaje no existe");
            }
        }

        public void ModifyReservationState(ReservationUpdateModel reservationUpdate)
        {
            Reservation reservation = reservationRepository.Get(reservationUpdate.ReservationId);
            State state = stateRepository.Get(reservationUpdate.StateId);
            if (reservation != null && state != null)
            {
                reservation.State = state;
                reservation.StateDescription = reservationUpdate.StateDescription;
                reservationRepository.Update(reservation);
                reservationRepository.Save();
            }
            else
            {
                throw new InvalidOperationException("La reserva o el estado no existen");
            }
        }

        public void ModifyAdmin(Administrator admin)
        {
            if (userRepository.GetAdminByMail(admin.Mail) != null)
            {
                userRepository.Update(admin);
                userRepository.Save();
            }
            else
            {
                throw new InvalidOperationException("El administrador no existe");
            }
        }

        public void RemoveAdmin(int adminId)
        {
            Person admin = personRepository.Get(adminId);
            if (admin != null)
            {
                personRepository.Delete(admin);
                personRepository.Save();
            }
            else
            {
                throw new InvalidOperationException("El administrador no existe");
            }
        }

        public void RemoveLodging(int lodgingId)
        {
            Lodging lodging = lodgingRepository.Get(lodgingId);
            if (lodging != null)
            {
                lodgingRepository.Delete(lodging);
                lodgingRepository.Save();
            }
            else
            {
                throw new InvalidOperationException("El hospedaje no existe");
            }
        }
    }
}
