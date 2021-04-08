using MoneyManager.DataAccess.Contexts;
using MoneyManager.DataAccess.Repositories;

namespace MoneyManager.DataAccess
{
    public class UnitOfWork
    {
        private AppDbContext _context;
        private UserRepository _userRepository;
        private AssetRepository _assetRepository;
        private CategoryRepository _categoryRepository;
        private TransactionRepository _transactionRepository;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public UserRepository Users
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

        public AssetRepository Assets
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

        public CategoryRepository Categories
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

        public TransactionRepository Transactions
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

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
