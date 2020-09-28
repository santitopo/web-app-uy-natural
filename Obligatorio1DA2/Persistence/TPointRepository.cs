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
        public TPointRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<TouristicPoint> FindByRegion(int regionId)
        {
            UyNaturalContext context2 = context as UyNaturalContext;
            IEnumerable<TouristicPoint> filteredTPoints = context2.TouristicPoints
                .Include(x => x.Region)
                .Include(x => x.Categories)
                .ThenInclude(x => x.Category)
                .Where(x => x.Region.Id == regionId);

            return filteredTPoints;
        }

        public IEnumerable<TouristicPoint> FindByRegionCat(int regionId, IEnumerable<int> categories)
        {
            UyNaturalContext context2 = context as UyNaturalContext;

            //First we include the Categories list(intermediate class). Then, with .thenInclude, 
            // we include the category attribute of the intermediate class. This way we include all 
            // the categories for each touristic point. The newtonsoftJson fixes the loop inclusion.

            IEnumerable<TouristicPoint> regionTPoints = context2.TouristicPoints
                .Include(x => x.Region)
                .Include(x => x.Categories)
                .ThenInclude(x => x.Category)
                .Where(x => x.Region.Id == regionId)
                .Where(x => x.Categories.Any(val => categories.Contains(val.CategoryId)));
            
            return regionTPoints;
        }

        public new IEnumerable<TouristicPoint> GetAll(string[] includes)
        {
            //Specifically for TPoints, the includes are not used because of the many to many relationship.

            UyNaturalContext context2 = context as UyNaturalContext;
            IEnumerable<TouristicPoint> tpoints = context2.TouristicPoints
                .Include(x => x.Region)
                .Include(x => x.Categories)
                .ThenInclude(x => x.Category);
            return tpoints;
        }
    }
}
