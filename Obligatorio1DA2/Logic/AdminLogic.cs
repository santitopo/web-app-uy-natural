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

        public AdminLogic(ITPointRepository repository, IRepository<Region> regionRepository, IRepository<Category> categoryRepository)
        {
            this.tpRepository = repository;
            this.regionRepository = regionRepository;
            this.categoryRepository = categoryRepository;
        }

        public Administrator AddAdmin(Administrator anAdmin)
        {
            throw new NotImplementedException();
        }

        public Lodging AddLodging(Lodging aLodging)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public void ModifyReservationState(int reservationId, int stateId, string aDescription)
        {
            throw new NotImplementedException();
        }

        public void RemoveAdmin(int adminId)
        {
            throw new NotImplementedException();
        }

        public void RemoveLodging(int lodgingId)
        {
            throw new NotImplementedException();
        }
    }
}
