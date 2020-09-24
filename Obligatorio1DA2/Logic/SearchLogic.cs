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
        private IRepository<Region> repository;

        public SearchLogic(IRepository<Region> repository)
        {
            this.repository = repository;
        }

        public IEnumerable<Region> GetAllRegions()
        {
            return repository.GetAll();
        }

        public IEnumerable<TouristicPoint> GetTPointsByRegion(int regionId)
        {
            return null;
        }

        public IEnumerable<TouristicPoint> GetTPointsByRegionCat(int regionId, int category)
        {
            TouristicPoint[] a = { };
            return a;
        }

        public IEnumerable<Category> GetAllCategories()
        {
            Category[] a = { new Category("metropolitana"), new Category("CentroSur") };
            return a;
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
