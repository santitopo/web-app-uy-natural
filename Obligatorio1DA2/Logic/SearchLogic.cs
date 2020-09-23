using Domain;
using LogicInterface;
using System;
using System.Collections.Generic;
using System.Text;
using Models;

namespace Logic
{
    public class SearchLogic : ISearchLogic
    {
        public IEnumerable<Region> GetAllRegions()
        {
            Region[] a = { new Region("metropolitana"), new Region("CentroSur") };
            return a;
        }

        public IEnumerable<TouristicPoint> GetTPointsByRegion(int regionId)
        {
            TouristicPoint a = new TouristicPoint()
            {
                Name = "name1",
                Description = "descrp",
                Region = new Region(String.Format("region{0}",regionId)),
                Categories = null,
                Image = "img1.jpg"
            };

            TouristicPoint[] b = { a};
            return b;
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
                Categories = null,
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
        public IEnumerable<LodgingSearchResultModel> SearchLodgings(LodgingSearchModel Search)
        {
            throw new NotImplementedException();
        }
    }
}
