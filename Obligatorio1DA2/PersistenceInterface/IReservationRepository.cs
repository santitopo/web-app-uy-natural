using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersistenceInterface
{
    public interface IReservationRepository : IRepository<Reservation>
    {
        bool Exists(Guid code);
        Reservation FindbyCode(Guid code);
        State GetDefaultState();
    }
}
