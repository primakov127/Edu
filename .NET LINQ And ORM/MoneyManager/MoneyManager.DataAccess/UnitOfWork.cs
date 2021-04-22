using MoneyManager.DataAccess.Contexts;
using MoneyManager.DataAccess.Models;
using MoneyManager.DataAccess.Repositories;
using MoneyManager.DataAccess.SeedWork;

namespace MoneyManager.DataAccess
{
    public class UnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
