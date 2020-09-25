using System;
using System.Collections.Generic;
using System.Text;
using Domain;
using Microsoft.EntityFrameworkCore;
using PersistenceInterface;
using System.Linq;

namespace Persistence
{
    public class TPointRepository : Repository<TouristicPoint>, ITPointRepository

    {
        //protected DbSet<TouristicPoint> DbSet;
        //protected UyNaturalContext context;

        public TPointRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<TouristicPoint> FindByRegion(int regionId)
        {
            UyNaturalContext context2 = context as UyNaturalContext;
            IEnumerable<TouristicPoint> example = context2.TouristicPoints.Include("Region").ToList();


            IEnumerable<TouristicPoint> filteredTPoints = context2.TouristicPoints.Include("Region").Where(x => x.Region.Id == regionId);
            return filteredTPoints;
        }


    }
}
