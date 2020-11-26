using Domain;
using Microsoft.EntityFrameworkCore;
using PersistenceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Persistence
{
    public class ReviewRepository : Repository<Review>, IReviewRepository
    {
        private readonly DbSet<Review> DbSet;
        private readonly DbContext context;

        public ReviewRepository(DbContext context) : base(context)
        {
            this.DbSet = context.Set<Review>();
            this.context = context;
        }


        public bool ReviewExists(Guid reservationCode)
        {
            Review review = DbSet.Include(x => x.Reservation).Where(x => x.Reservation.Code.Equals(reservationCode)).FirstOrDefault();
            return review != null;
        }
    }
}
