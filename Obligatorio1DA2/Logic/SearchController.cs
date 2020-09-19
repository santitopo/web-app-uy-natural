using Domain;
using LogicInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class SearchController : ISearchController
    {
        public IEnumerable<string> GetAllRegions()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TouristicPoints> GetTPointsByRegion(int regionId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TouristicPoints> GetTPointsByRegionCat(int regionId, int category)
        {
            throw new NotImplementedException();
        }
    }
}
