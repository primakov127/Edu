using MoneyManager.DataAccess.Contexts;
using MoneyManager.DataAccess.Models;
using MoneyManager.DataAccess.SeedWork;
using System;
using System.Linq;

namespace MoneyManager.DataAccess.Repositories
{
    public class CategoryRepository : IRepository<Category>
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public IQueryable<Category> GetAll()
        {
            return _context.Categories;
        }

        public Category Get(Guid id)
        {
            return _context.Categories.Find(id);
        }

        public void Create(Category item)
        {
            _context.Categories.Add(item);
        }

        public void Update(Category item)
        {
            _context.Categories.Update(item);
        }

        public void Delete(Guid id)
        {
            Category category = _context.Categories.Find(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
            }
        }
    }
}
