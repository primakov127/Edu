using MoneyManager.DataAccess.Models;
using System;
using System.Linq;

namespace MoneyManager.DataAccess.SeedWork
{
    public interface IUserRepository
    {
        IQueryable<User> GetAll();
        User Get(Guid id);
        void Create(User item);
        void Update(User item);
        void Delete(Guid id);
    }
}
