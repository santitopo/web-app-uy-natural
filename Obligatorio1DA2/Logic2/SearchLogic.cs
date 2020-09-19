using Domain;
using LogicInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class SearchLogic : ISearchLogic
    {
        public IEnumerable<string> GetAllRegions()
        {
            string[] a = {"metropolitana", "CentroSur"};
            return a;
        }

        public IEnumerable<TouristicPoints> GetTPointsByRegion(int regionId)
        {
            TouristicPoints[] a = { };
            return a;
        }

        public IEnumerable<TouristicPoints> GetTPointsByRegionCat(int regionId, int category)
        {
            TouristicPoints[] a = { };
            return a;
        }
    }
}
