using MoneyManager.DataAccess.Contexts;
using MoneyManager.DataAccess.Models;
using MoneyManager.DataAccess.Repositories;
using MoneyManager.DataAccess.SeedWork;

namespace MoneyManager.DataAccess
{
    public class UnitOfWork : UnitOfWorkBase
    {
        private IRepository<User> _userRepository;
        private IRepository<Asset> _assetRepository;
        private IRepository<Category> _categoryRepository;
        private IRepository<Transaction> _transactionRepository;

        public UnitOfWork(AppDbContext context) : base(context) { }

        public override IRepository<User> Users
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new UserRepository(_context);
                }
                return _userRepository;
            }
        }

        public override IRepository<Asset> Assets
        {
            get
            {
                if (_assetRepository == null)
                {
                    _assetRepository = new AssetRepository(_context);
                }
                return _assetRepository;
            }
        }

        public override IRepository<Category> Categories
        {
            get
            {
                if (_categoryRepository == null)
                {
                    _categoryRepository = new CategoryRepository(_context);
                }
                return _categoryRepository;
            }
        }

        public override IRepository<Transaction> Transactions
        {
            get
            {
                if (_transactionRepository == null)
                {
                    _transactionRepository = new TransactionRepository(_context);
                }
                return _transactionRepository;
            }
        }

        public override void Save()
        {
            _context.SaveChanges();
        }
    }
}
