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
            IEnumerable<TouristicPoint> filteredTPoints = context2.TouristicPoints.Include("Region").Where(x => x.Region.Id == regionId);
            return filteredTPoints;
        }

        public IEnumerable<TouristicPoint> FindByRegionCat(int regionId, IEnumerable<int> categories)
        {
            UyNaturalContext context2 = context as UyNaturalContext;
            
            //First we include the Categories list(intermediate class). Then, with .thenInclude, 
            // we include the category attribute of the intermediate class.
            //Doing this we include all the categories for each touristic point
            
            IEnumerable<TouristicPoint> regionTPoints = context2.TouristicPoints
                .Include(x => x.Region)
             //   .Where(x => x.Region.Id == regionId)
                .Include(x => x.Categories)
                .ThenInclude(x => x.Category);
            

            return regionTPoints;
        }
    }
}
