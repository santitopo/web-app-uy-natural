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
            throw new NotImplementedException("Implementacion no utilizada");
        }

        public IEnumerable<TouristicPointOutModel> GetAllTpoints()
        {
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
