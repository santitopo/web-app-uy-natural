using Domain;
using PersistenceInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence
{
    public class RepositoryMemory<T> : IRepository<T> where T : class
    {
        private List<T> list;

        public RepositoryMemory(){
            list = new List<T>();
        }

        public void Create(T entity)
        {
            list.Add(entity);
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public T Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
