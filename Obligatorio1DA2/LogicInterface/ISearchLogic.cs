using Domain;
using System;
using System.Collections.Generic;
using System.Text;
using Models;

namespace LogicInterface
{
    public interface ISearchLogic
    {
        IEnumerable<Region> GetAllRegions();

        IEnumerable<TouristicPoint> GetTPointsByRegion(int regionId);

        IEnumerable<TouristicPoint> GetTPointsByRegionCat(int regionId, IEnumerable<int> categories);

        IEnumerable<Category> GetAllCategories();
        IEnumerable<TouristicPoint> GetAllTPoints();

        

    }
}
