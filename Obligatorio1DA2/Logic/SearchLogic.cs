using Domain;
using LogicInterface;
using System;
using System.Collections.Generic;
using System.Text;
using Models;
using PersistenceInterface;

namespace Logic
{
    public class SearchLogic : ISearchLogic
    {
        private IRepository<Region> regionRepository;
        private IRepository<Category> categoryRepository;
        private ITPointRepository tpointRepository;

        public SearchLogic(IRepository<Region> regionRepository, 
                           IRepository<Category> categoryRepository,
                           ITPointRepository tpointRepository)
        {
            this.regionRepository = regionRepository;
            this.categoryRepository = categoryRepository;
            this.tpointRepository = tpointRepository;
        }

        public IEnumerable<Region> GetAllRegions()
        {
            string[] param = {};
            return regionRepository.GetAll(param);
        }

        public IEnumerable<TouristicPoint> GetTPointsByRegion(int regionId)
        {
            if (regionRepository.Get(regionId) != null)
            {
                IEnumerable<TouristicPoint> filteredTPoints = tpointRepository.FindByRegion(regionId);
                return filteredTPoints;
            }
            else
            {
                throw new InvalidOperationException("La region no existe");
            }
        }
        
        public IEnumerable<TouristicPoint> GetAllTPoints()
        {
            string[] param = { "Region" };
            return tpointRepository.GetAll(param);
        }

        public IEnumerable<Category> GetAllCategories()
        {
            string[] param = {};
            return categoryRepository.GetAll(param);
        }

        public IEnumerable<TouristicPoint> FindByRegionCat(int regionId, IEnumerable<int> categories)
        {
            if (regionRepository.Get(regionId) != null)
            {
                return tpointRepository.FindByRegionCat(regionId, categories);
            }
            else
            {
                throw new InvalidOperationException("La region no existe");
            }
        }

        //Not implemented

        //PRE:
        //POS: Returns a list of Lodgings with total prices for the period
        public IEnumerable<LodgingSearchResultModel> SearchLodgings(LodgingSearchModel search)
        {
            throw new NotImplementedException();
        }
    }
}
