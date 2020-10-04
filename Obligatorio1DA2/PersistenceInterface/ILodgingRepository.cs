using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersistenceInterface
{
    public interface ILodgingRepository : IRepository<Lodging>
    {
        bool Exists(string name, string direction);
    }
}
