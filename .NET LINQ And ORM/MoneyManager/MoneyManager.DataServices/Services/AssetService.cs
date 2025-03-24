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
    public class AssetService : IAssetService
    {
        private readonly IAssetRepository _assetRepository;
        private readonly IUserRepository _userRepository;

        public AssetService(IAssetRepository assetRepository, IUserRepository userRepository)
        {
            _assetRepository = assetRepository;
            _userRepository = userRepository;
        }

        public IEnumerable<AssetBalanceInformationDTO> GetUserAssetsBalanceInformation(Guid userId)
        {
            var user = _userRepository.Get(userId);
            if (user == null)
            {
                throw new ArgumentException($"There is no user with {userId} Id.");
            }

            var userAssets = _assetRepository.GetAll().Where(a => a.UserId == user.Id).Include(a => a.Transactions).ThenInclude(t => t.Category);

            var result = new List<AssetBalanceInformationDTO>();
            foreach (var asset in userAssets)
            {
                decimal assetBalance = 0;
                foreach (var transaction in asset.Transactions)
                {
                    if (transaction.Category.Type == CategoryType.Expense)
                    {
                        assetBalance = assetBalance - transaction.Amount;
                    }
                    else if (transaction.Category.Type == CategoryType.Income)
                    {
                        assetBalance = assetBalance + transaction.Amount;
                    }
                }

                var assetBalanceInfo = new AssetBalanceInformationDTO
                {
                    Id = asset.Id,
                    Name = asset.Name,
                    Balance = assetBalance
                };

                result.Add(assetBalanceInfo);
            }

            return result;
        }
    }
}
