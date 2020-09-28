using System;
using System.Collections.Generic;
using System.Text;
using Domain;

namespace PersistenceInterface
{
    public interface ITPointRepository : IRepository<TouristicPoint>
    {
        IEnumerable<TouristicPoint> FindByRegion(int regionId);

        IEnumerable<TouristicPoint> FindByRegionCat(int regionId, IEnumerable<int> categories);

    }
}