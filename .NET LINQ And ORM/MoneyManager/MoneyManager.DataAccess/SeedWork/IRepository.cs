using System;
using System.Linq;

namespace MoneyManager.DataAccess.SeedWork
{
    interface IRepository<T>
    {
        IQueryable<T> GetAll();
        T Get(Guid id);
        void Create(T item);
        void Update(T item);
        void Delete(Guid id);
    }
}
