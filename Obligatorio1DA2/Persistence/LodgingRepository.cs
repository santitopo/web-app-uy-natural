using System;
using System.Collections.Generic;
using System.Text;
using Domain;
using Microsoft.EntityFrameworkCore;
using PersistenceInterface;
using System.Linq;

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

        public bool Exists(string name, string direction)
        {
            Lodging lodging = DbSet.Where(x => x.Name == name && x.Direction == direction).FirstOrDefault();
            return lodging != null;
        }

    }
}
