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
    public class TransactionService : ITransactionService
    {
        private readonly UnitOfWorkBase _unitOfWork;

        public TransactionService(UnitOfWorkBase unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<TransactionInformationDTO> GetUserTransactionsInformation(Guid userId)
        {
            var user = _unitOfWork.Users.Get(userId);
            if (user == null)
            {
                throw new ArgumentException($"There is no user with {userId} Id.");
            }

            var userTransactions = _unitOfWork.Transactions
                .GetAll()
                .Include(t => t.Asset)
                .Include(t => t.Category)
                    .ThenInclude(t => t.Parent)
                .Where(t => t.Asset.UserId == user.Id)
                .OrderByDescending(t => t.Date)
                .OrderBy(t => t.Asset.Name)
                .OrderBy(t => t.Category.Name);

            var result = userTransactions.Select(t => new TransactionInformationDTO
            {
                AssetName = t.Asset.Name,
                CategoryName = t.Category.Name,
                ParentCategoryName = t.Category.Parent == null ? null : t.Category.Parent.Name,
                Amount = t.Amount,
                Date = t.Date,
                Comment = t.Comment
            });

            return result;
        }

        public IEnumerable<TotalIncomeAndExpensesDTO> GetUserPeriodIncomeAndExpenses(Guid userId, DateTime startDate, DateTime endDate)
        {
            var user = _unitOfWork.Users.Get(userId);
            if (user == null)
            {
                throw new ArgumentException($"There is no user with {userId} Id.");
            }

            var userTransactions = _unitOfWork.Transactions
                .GetAll()
                .Include(t => t.Category)
                .Include(t => t.Asset)
                .Where(t => t.Asset.UserId == user.Id)
                .Where(t => t.Date >= startDate && t.Date <= endDate)
                .OrderBy(t => t.Date)
                .AsEnumerable();
            var userTransactionsGroupedByMonthAndYear = userTransactions.GroupBy(t => new { t.Date.Year, t.Date.Month });

            var result = new List<TotalIncomeAndExpensesDTO>();
            foreach (var monthAndYearTransactions in userTransactionsGroupedByMonthAndYear)
            {
                decimal income = 0;
                decimal expense = 0;
                foreach (var transaction in monthAndYearTransactions)
                {
                    if (transaction.Category.Type == CategoryType.Expense)
                    {
                        expense = expense + transaction.Amount;
                    }
                    else if (transaction.Category.Type == CategoryType.Income)
                    {
                        income = income + transaction.Amount;
                    }
                }

                result.Add(new TotalIncomeAndExpensesDTO
                {
                    Expense = expense,
                    Income = income,
                    Month = monthAndYearTransactions.Key.Month,
                    Year = monthAndYearTransactions.Key.Year
                });
            }

            return result;
        }

        public void DeleteUserCurrentMonthTransactions(Guid userId)
        {
            var transactions = _unitOfWork.Transactions
                .GetAll()
                .Include(t => t.Asset)
                .Where(t => t.Asset.UserId == userId)
                .Where(t => t.Date.Month == DateTime.Now.Month);

            _unitOfWork.Transactions.Delete(transactions);
            _unitOfWork.Save();
        }
    }
}
