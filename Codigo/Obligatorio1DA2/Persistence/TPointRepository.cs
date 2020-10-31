using System;
using System.Collections.Generic;
using System.Text;
using Domain;
using Models;
using Microsoft.EntityFrameworkCore;
using PersistenceInterface;
using System.Linq;

namespace Persistence
{
    public class TPointRepository : Repository<TouristicPoint>, ITPointRepository
    {
        private readonly DbSet<TouristicPoint> DbSet;
        private readonly DbContext context;

        public TPointRepository(DbContext context) : base(context)
        {
            this.DbSet = context.Set<TouristicPoint>();
            this.context = context;
        }

        public IEnumerable<TouristicPoint> FindByRegion(int regionId)
        {
            IEnumerable<TouristicPoint> filteredTPoints = DbSet
                .Include(x => x.Region)
                .Include(x => x.Categories)
                .ThenInclude(x => x.Category)
                .Where(x => x.Region.Id == regionId);

            return filteredTPoints;
        }

        public IEnumerable<TouristicPoint> FindByRegionCat(int regionId, IEnumerable<int> categories)
        {
            //First we include the Categories list(intermediate class). Then, with .thenInclude, 
            // we include the category attribute of the intermediate class. This way we include all 
            // the categories for each touristic point. The newtonsoftJson fixes the loop inclusion.

            IEnumerable<TouristicPoint> regionTPoints = DbSet
                .Include(x => x.Region)
                .Include(x => x.Categories)
                .ThenInclude(x => x.Category)
                .Where(x => x.Region.Id == regionId)
                .Where(x => x.Categories.Any(val => categories.Contains(val.CategoryId)));
            
            return regionTPoints;
        }

        public new IEnumerable<TouristicPoint> GetAll(string[] s)
        {
            //DON'T USE GetAll with Tpoints. Use GetAllTpoints instead.
            throw new NotImplementedException("Implementacion no utilizada");
        }

        public IEnumerable<TouristicPointOutModel> GetAllTpoints()
        {
            //Specifically for TPoints, the includes are not used because of the many to many relationship.

            //IEnumerable<TouristicPoint> tpoints = DbSet
            //    .Include(x => x.Region)
            //    .Include(x => x.Categories)
            //    .ThenInclude(x => x.Category);

            //Turn inner classes into models

             var tpoints = DbSet
               .Include(x => x.Region)
               .Include(x => x.Categories)
               .ThenInclude(x => x.Category)
               .Select (
                g => new TouristicPointOutModel()
                {
                    Description = g.Description,
                    Id = g.Id,
                    Image = g.Image,
                    Name = g.Name,
                    Region = g.Region,
                    Categories = g.Categories.Select(c => new CategoryModel() { CategoryId = c.CategoryId, Name = c.Category.Name }).ToList()
                });

            return tpoints;
        }

        public TouristicPoint GetByName(string name)
        {
            TouristicPoint tp = DbSet.Where(x => x.Name == name).FirstOrDefault();
            return tp;
        }

        public bool Exists(string name)
        {
            TouristicPoint tp = DbSet.Where(x => x.Name == name).FirstOrDefault();
            return tp != null;
        }


       
    }
}
