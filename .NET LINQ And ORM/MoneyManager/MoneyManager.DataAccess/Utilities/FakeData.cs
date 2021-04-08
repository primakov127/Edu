using Bogus;
using MoneyManager.DataAccess.Models;
using System;
using System.Collections.Generic;

namespace MoneyManager.DataAccess.Utilities
{
    public static class FakeData
    {
        public static List<Transaction> Transactions = new List<Transaction>();
        public static List<Category> Categories = new List<Category>();
        public static List<Asset> Assets = new List<Asset>();
        public static List<User> Users = new List<User>();

        private static Faker _f;
        private static string[][] _assetNames =
        {
            new string[] { "debit cards", "bank account", "loan" },
            new string[] { "cash", "bank account", "loan" },
            new string[] { "cash", "debit cards", "loan" },
            new string[] { "cash", "bank account", "debit cards" }
        };
        private static string[] _categoryNames = { "Food", "Transportation", "Salary", "Bonus" };
        private static CategoryType[] _categoryTypes = { CategoryType.Expense, CategoryType.Expense, CategoryType.Income, CategoryType.Income };
        private static string[][] _subcategoryNames =
        {
            new string[] { "Grocery", "Street food", "Coffe" },
            new string[] { "Taxi", "Public transport", "Parking" }
        };

        public static void Init(int userCount, int transPerUserCount)
        {
            Randomizer.Seed = new Random(3157347);
            _f = new Faker();

            GenerateUsers(userCount);
            GenerateCategories();
            GenerateTransactions(transPerUserCount);
        }

        private static void GenerateUsers(int userCount)
        {
            for (int i = 0; i < userCount; i++)
            {
                var user = new User
                {
                    Id = _f.Random.Guid(),
                    Name = _f.Internet.UserName(),
                    Email = _f.Internet.Email(),
                    Hash = _f.Random.Hash(1024),
                    Salt = _f.Random.Hash(_f.Random.Int(256, 1024))
                };

                Users.Add(user);
                GenerateAssets(user);
            }
        }

        private static void GenerateAssets(User u)
        {
            var assets = _f.PickRandom(_assetNames);
            for (int i = 0; i < assets.Length; i++)
            {
                var asset = new Asset
                {
                    Id = _f.Random.Guid(),
                    Name = assets[i],
                    UserId = u.Id
                };

                Assets.Add(asset);
            }
        }

        private static void GenerateCategories()
        {
            for (int i = 0; i < _categoryNames.Length; i++)
            {
                var category = new Category
                {
                    Id = _f.Random.Guid(),
                    Name = _categoryNames[i],
                    Type = _categoryTypes[i],
                    ParentId = null
                };

                Categories.Add(category);
                GenerateSubcategories(category, i);
            }
        }

        private static void GenerateSubcategories(Category c, int num)
        {
            if (num >= _subcategoryNames.Length)
            {
                return;
            }

            var subcategoryNames = _subcategoryNames[num];
            for (int i = 0; i < subcategoryNames.Length; i++)
            {
                var subcategory = new Category
                {
                    Id = _f.Random.Guid(),
                    Name = subcategoryNames[i],
                    Type = c.Type,
                    ParentId = c.Id
                };

                Categories.Add(subcategory);
            }
        }

        private static void GenerateTransactions(int transPerUserCount)
        {
            foreach (var asset in Assets)
            {
                for (int i = 0; i < transPerUserCount; i++)
                {
                    var category = _f.PickRandom(Categories);
                    var transaction = new Transaction
                    {
                        Id = _f.Random.Guid(),
                        CategoryId = category.Id,
                        Amount = Decimal.Round(_f.Random.Decimal(0.2m, 234.5m), 3),
                        Date = _f.Date.Recent(),
                        AssetId = asset.Id,
                        Comment = _f.Lorem.Sentence(_f.Random.Int(5, 10))
                    };

                    Transactions.Add(transaction);
                }
            }
        }
    }
}
