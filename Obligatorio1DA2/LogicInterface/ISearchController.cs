using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicInterface
{
    public interface ISearchController
    {
        IEnumerable<string> GetAllRegions();

        IEnumerable<TouristicPoints> GetTPointsByRegion(int regionId);

        IEnumerable<TouristicPoints> GetTPointsByRegionCat(int regionId, int category);
    }
}
