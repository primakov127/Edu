using Microsoft.EntityFrameworkCore;
using MoneyManager.DataAccess.Models;
using MoneyManager.DataAccess.Utilities;

namespace MoneyManager.DataAccess.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            FakeData.Init(10, 4);

            modelBuilder.Entity<User>().HasData(FakeData.Users);
            modelBuilder.Entity<Asset>().HasData(FakeData.Assets);
            modelBuilder.Entity<Category>().HasData(FakeData.Categories);
            modelBuilder.Entity<Transaction>().HasData(FakeData.Transactions);
        }
    }
}
