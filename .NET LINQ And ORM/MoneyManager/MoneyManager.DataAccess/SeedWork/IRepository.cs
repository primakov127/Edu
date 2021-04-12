using System;
using System.Collections.Generic;
using System.Linq;

namespace MoneyManager.DataAccess.SeedWork
{
    public interface IRepository<T>
    {
        IQueryable<T> GetAll();
        T Get(Guid id);
        void Create(T item);
        void Update(T item);
        void Delete(Guid id);
        void Delete(IEnumerable<T> items);
    }
}
