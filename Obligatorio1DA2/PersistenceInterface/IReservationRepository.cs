using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersistenceInterface
{
    public interface IReservationRepository : IRepository<Reservation>
    {
        bool Exists(Guid code);
        Reservation FindByCode(Guid code);
        State GetDefaultState();
    }
}
