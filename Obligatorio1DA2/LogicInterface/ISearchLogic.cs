using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicInterface
{
    public interface ISearchLogic
    {
        IEnumerable<Region> GetAllRegions();

        IEnumerable<TouristicPoint> GetTPointsByRegion(int regionId);

        IEnumerable<TouristicPoint> GetTPointsByRegionCat(int regionId, int category);

        IEnumerable<Category> GetAllCategories();
        IEnumerable<TouristicPoint> GetAllTPoints();



    }
}
