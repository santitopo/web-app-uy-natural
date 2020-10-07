using Domain;
using LogicInterface;
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
        private readonly IUserRepository userRepository;
        private readonly IRepository<Person> personRepository;

        public AdminLogic(ITPointRepository repository, IRepository<Region> regionRepository, 
            IRepository<Category> categoryRepository, ILodgingRepository lodgingRepository, 
            IRepository<Person> personRepository, IUserRepository userRepository,
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
                return null;
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
                return null;
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
                return null;
            }
        }

        public void ModifyLodgingCapacity(int lodgingId, bool isFull)
        {
            if (lodgingRepository.Get(lodgingId) != null)
            {
                Lodging lodging = lodgingRepository.Get(lodgingId);
                lodging.Capacity = isFull;
                lodgingRepository.Update(lodging);
                lodgingRepository.Save();
            }
        }

        public void ModifyReservationState(int stateId, int reservationId, string aDescription)
        {
            if (reservationRepository.Get(reservationId) != null && stateRepository.Get(stateId) != null)
            {
                Reservation reservation = reservationRepository.Get(reservationId);
                State state = stateRepository.Get(stateId);
                reservation.State = state;
                reservation.StateDescription = aDescription;
                reservationRepository.Update(reservation);
                reservationRepository.Save();
            }

        }

        public void ModifyAdmin(Administrator admin)
        {
            if (userRepository.GetAdminByMail(admin.Mail) == null)
            {
                userRepository.Update(admin);
                userRepository.Save();
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
        }

        public void RemoveLodging(int lodgingId)
        {
            Lodging lodging = lodgingRepository.Get(lodgingId);
            if (lodging != null)
            {
                lodgingRepository.Delete(lodging);
                lodgingRepository.Save();
            }
        }
    }
}
