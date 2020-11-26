using Domain;
using Microsoft.EntityFrameworkCore;
using PersistenceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Persistence
{
    public class LodgingRepository : Repository<Lodging>, ILodgingRepository
    {
        private readonly DbSet<Lodging> DbSet;
        private readonly DbContext context;

        public LodgingRepository(DbContext context) : base(context)
        {
            this.DbSet = context.Set<Lodging>();
            this.context = context;
        }

        public IEnumerable<Lodging> FindByTPoint(int tpointId)
        {
            IEnumerable<Lodging> filteredLodging = DbSet
                .Include(x => x.TouristicPoint)
                .Where(x => x.TouristicPoint.Id == tpointId && !x.IsDeleted);

            return filteredLodging;
        }

        public bool Exists(string name, string direction)
        {
            Lodging lodging = DbSet.Where(x => x.Name == name && x.Direction == direction && !x.IsDeleted).FirstOrDefault();
            return lodging != null;
        }

        public new void  Delete(Lodging entity)
        {
            entity.IsDeleted = true;
        }

        public new IEnumerable<Lodging> GetAll(string[] includes)
        {
            IEnumerable<Lodging> lodgings = DbSet.Include(x => x.TouristicPoint).Where(x => !x.IsDeleted);
            return lodgings;
        }

        public new Lodging Get(int id)
        {
            Lodging lodging = DbSet.Find(id);
            if (lodging != null)
            {
                return lodging.IsDeleted ? null : lodging;
            }
            else
            {
                return null;
            }
        }
        public new void Create(Lodging entity)
        {
            Lodging lodging = DbSet.Where(x => x.Name == entity.Name && x.Direction == entity.Direction).FirstOrDefault();
            if (lodging != null)
            {
                lodging.IsDeleted = false;
                DbSet.Update(lodging);
            }
            else
            {
                DbSet.Add(entity);
            }
        }

    }
}

