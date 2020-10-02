using Domain;
using System;
using System.Collections.Generic;
using System.Text;
using Models;

namespace LogicInterface
{
    public interface ISearchLogic
    {
        //Done
        IEnumerable<Region> GetAllRegions();

        IEnumerable<Category> GetAllCategories();

        IEnumerable<TouristicPoint> GetTPointsByRegion(int regionId);

        //Missing
        IEnumerable<TouristicPoint> GetAllTPoints();

        IEnumerable<TouristicPoint> FindByRegionCat(int regionId, IEnumerable<int> categories);

    }
}
