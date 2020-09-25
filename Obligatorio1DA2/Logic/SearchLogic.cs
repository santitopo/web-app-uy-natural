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
        private IRepository<TouristicPoint> tpointRepository;

        public SearchLogic(IRepository<Region> regionRepository, 
                           IRepository<Category> categoryRepository,
                           IRepository<TouristicPoint> tpointRepository)
        {
            this.regionRepository = regionRepository;
            this.categoryRepository = categoryRepository;
            this.tpointRepository = tpointRepository;
        }

        public IEnumerable<Region> GetAllRegions()
        {
            return regionRepository.GetAll();
        }

        public IEnumerable<TouristicPoint> GetTPointsByRegion(int regionId)
        {
            Region region = regionRepository.Get(regionId);
            IEnumerable <TouristicPoint> tpoints = tpointRepository.GetAll();
            List<TouristicPoint> ret = new List<TouristicPoint>();
            foreach (TouristicPoint tp in tpoints) {
                if (tp.Region.Equals(region))
                {
                    ret.Add(tp);
                }
            }
            
            return ret;
        }

        public IEnumerable<TouristicPoint> GetTPointsByRegionCat(int regionId, int category)
        {
            TouristicPoint[] a = { };
            return a;
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return categoryRepository.GetAll();
        }

        public IEnumerable<TouristicPoint> GetAllTPoints()
        {
            TouristicPoint a = new TouristicPoint()
            {
                Name = "name1",
                Description = "descrp",
                Region = new Region("region1"),
                TouristicPointsCategory = null,
                Image = "img1.jpg"
            };
            TouristicPoint[] b = { a };
            return b;
        }

        public IEnumerable<TouristicPoint> GetTPointsByRegionCat(int regionId, IEnumerable<int> category)
        {
            throw new NotImplementedException();
        }

        //PRE:
        //POS: Returns a list of Lodgings with total prices for the period
        public IEnumerable<LodgingSearchResultModel> SearchLodgings(LodgingSearchModel search)
        {
            throw new NotImplementedException();
        }

        public void AddRegions(Region region)
        {
            throw new NotImplementedException();
        }
    }
}
