using MoneyManager.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MoneyManager.DataAccess.SeedWork
{
    public interface ITransactionRepository
    {
        IQueryable<Transaction> GetAll();
        Transaction Get(Guid id);
        void Create(Transaction item);
        void Update(Transaction item);
        void Delete(Guid id);
        void Delete(IEnumerable<Transaction> items);
    }
}
