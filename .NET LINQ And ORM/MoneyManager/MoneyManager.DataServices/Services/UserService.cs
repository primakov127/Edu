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
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITransactionRepository _transactionRepository;

        public UserService(IUserRepository userRepository, ITransactionRepository transactionRepository)
        {
            _userRepository = userRepository;
            _transactionRepository = transactionRepository;
        }

        public UserDTO GetUser(string email)
        {
            return _userRepository
                .GetAll()
                .Where(u => u.Email.Equals(email))
                .Select(u => new UserDTO
                {
                    Id = u.Id,
                    Name = u.Name,
                    Email = u.Email,
                    Hash = u.Hash,
                    Salt = u.Salt
                })
                .FirstOrDefault();
        }

        public IEnumerable<UserInformationDTO> GetUsersInformationSortedByName()
        {
            return _userRepository
                .GetAll()
                .Select(u => new UserInformationDTO
                {
                    Id = u.Id,
                    Name = u.Name,
                    Email = u.Email
                })
                .OrderBy(u => u.Name);
        }

        public UserBalanceInformationDTO GetUserBalanceInformation(Guid userId)
        {
            var user = _userRepository.Get(userId);
            if (user == null)
            {
                throw new ArgumentException($"There is no user with {userId} Id.");
            }

            var userTransactions = _transactionRepository.GetAll().Include(t => t.Asset).Include(t => t.Category).Where(t => t.Asset.UserId == user.Id);

            decimal balance = 0;
            foreach (var transaction in userTransactions)
            {
                if (transaction.Category.Type == CategoryType.Expense)
                {
                    //SUM
                    balance = balance - transaction.Amount;
                }
                else if (transaction.Category.Type == CategoryType.Income)
                {
                    balance = balance + transaction.Amount;
                }
            }

            return new UserBalanceInformationDTO
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Balance = balance
            };
        }
    }
}
