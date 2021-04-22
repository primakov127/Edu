using MoneyManager.DataAccess.Contexts;
using MoneyManager.DataAccess.Models;
using MoneyManager.DataAccess.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MoneyManager.DataAccess.Repositories
{
    public class AssetRepository : IAssetRepository
    {
        private readonly AppDbContext _context;

        public AssetRepository(AppDbContext context)
        {
            _context = context;
        }

        public IQueryable<Asset> GetAll()
        {
            return _context.Assets;
        }

        public Asset Get(Guid id)
        {
            return _context.Assets.Find(id);
        }

        public void Create(Asset item)
        {
            _context.Assets.Add(item);
        }

        public void Update(Asset item)
        {
            _context.Assets.Update(item);
        }

        public void Delete(Guid id)
        {
            Asset asset = _context.Assets.Find(id);
            if (asset != null)
            {
                _context.Assets.Remove(asset);
            }
        }
    }
}
