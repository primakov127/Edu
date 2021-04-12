using MoneyManager.DataAccess.Contexts;
using MoneyManager.DataAccess.Models;

namespace MoneyManager.DataAccess.SeedWork
{
    public abstract class UnitOfWorkBase
    {
        protected AppDbContext _context;

        protected UnitOfWorkBase(AppDbContext context)
        {
            _context = context;
        }

        public abstract IRepository<User> Users { get; }
        public abstract IRepository<Asset> Assets { get; }
        public abstract IRepository<Category> Categories { get; }
        public abstract IRepository<Transaction> Transactions { get; }

        public abstract void Save();
    }
}
