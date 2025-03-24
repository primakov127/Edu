using MoneyManager.DataAccess.Models;
using System;
using System.Linq;

namespace MoneyManager.DataAccess.SeedWork
{
    public interface IAssetRepository
    {
        IQueryable<Asset> GetAll();
        Asset Get(Guid id);
        void Create(Asset item);
        void Update(Asset item);
        void Delete(Guid id);
    }
}
