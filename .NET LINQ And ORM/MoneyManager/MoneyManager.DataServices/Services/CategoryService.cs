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
        private UnitOfWorkBase _unitOfWork;

        public CategoryService(UnitOfWorkBase unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<CategoryAmountInformationDTO> GetUserCategoriesAmountInformationByType(Guid userId, CategoryType categoryType)
        {
            var user = _unitOfWork.Users.Get(userId);
            if (user == null)
            {
                throw new ArgumentException($"There is no user with {userId} Id.");
            }

            var userCategories = _unitOfWork.Categories
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
