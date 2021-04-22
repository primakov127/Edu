using Microsoft.EntityFrameworkCore;
using MoneyManager.DataAccess.Models;
using MoneyManager.DataAccess.SeedWork;
using MoneyManager.DataServices.DataTransferObjects;
using MoneyManager.DataServices.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MoneyManager.DataServices.Services
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository _categoryRepository;
        private IUserRepository _userRepository;

        public CategoryService(ICategoryRepository categoryRepository, IUserRepository userRepository)
        {
            _categoryRepository = categoryRepository;
            _userRepository = userRepository;
        }

        public IEnumerable<CategoryAmountInformationDTO> GetUserCategoriesAmountInformationByType(Guid userId, CategoryType categoryType)
        {
            var user = _userRepository.Get(userId);
            if (user == null)
            {
                throw new ArgumentException($"There is no user with {userId} Id.");
            }

            var userCategories = _categoryRepository
                .GetAll()
                .Include(c => c.Transactions.Where(t => t.Asset.UserId == user.Id))
                .Where(c => c.Type == categoryType).AsEnumerable();

            var result = userCategories
                .Select(c => new CategoryAmountInformationDTO
                {
                    CategoryName = c.Name,
                    Amount = c.Transactions.Aggregate(0m, (acc, t) => t.Amount)
                });

            return result;
        }
    }
}
