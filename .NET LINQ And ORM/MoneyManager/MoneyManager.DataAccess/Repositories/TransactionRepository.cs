﻿using MoneyManager.DataAccess.Contexts;
using MoneyManager.DataAccess.Models;
using MoneyManager.DataAccess.SeedWork;
using System;
using System.Linq;

namespace MoneyManager.DataAccess.Repositories
{
    public class TransactionRepository : IRepository<Transaction>
    {
        private AppDbContext _context;

        public TransactionRepository(AppDbContext context)
        {
            _context = context;
        }

        public IQueryable<Transaction> GetAll()
        {
            return _context.Transactions;
        }

        public Transaction Get(Guid id)
        {
            return _context.Transactions.Find(id);
        }

        public void Create(Transaction item)
        {
            _context.Transactions.Add(item);
        }

        public void Update(Transaction item)
        {
            _context.Transactions.Update(item);
        }

        public void Delete(Guid id)
        {
            Transaction transaction = _context.Transactions.Find(id);
            if (transaction != null)
            {
                _context.Transactions.Remove(transaction);
            }
        }
    }
}