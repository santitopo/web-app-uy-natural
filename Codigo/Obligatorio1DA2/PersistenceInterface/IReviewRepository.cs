using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersistenceInterface
{
    public interface IReviewRepository : IRepository<Review>
    {

        bool ReviewExists(Guid reservationCode);
    }
}
