using MoneyManager.DataAccess.Models;
using System;
using System.Linq;

namespace MoneyManager.DataAccess.SeedWork
{
    public interface ICategoryRepository
    {
        IQueryable<Category> GetAll();
        Category Get(Guid id);
        void Create(Category item);
        void Update(Category item);
        void Delete(Guid id);
    }
}
