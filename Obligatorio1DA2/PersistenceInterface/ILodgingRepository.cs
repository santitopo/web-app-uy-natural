using Domain;
using System;
using System.Collections.Generic;
using System.Text;


namespace PersistenceInterface
{
    public interface ILodgingRepository : IRepository<Lodging>
    {
        IEnumerable<Lodging> FindByTPoint(int id);
        bool Exists(string name, string direction);
    }
}
