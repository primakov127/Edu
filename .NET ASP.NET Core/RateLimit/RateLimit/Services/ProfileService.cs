using RateLimit.DataAccess.SeedWork;
using RateLimit.Models;
using RateLimit.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RateLimit.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IProfileRepository _profileRepository;

        public ProfileService(IProfileRepository profileRepository)
        {
            _profileRepository = profileRepository;
        }

        public IEnumerable<ProfileViewModel> GetProfiles<TKey>(int pageSize, int pageNum, string filter, Func<ProfileViewModel, TKey> keySelector)
        {
            return _profileRepository
                .GetAll()
                .Skip(pageNum * pageSize)
                .Take(pageSize)
                .Where(p => p.FirstName.ToLower().Contains(filter) || p.LastName.ToLower().Contains(filter))
                .Select(p => new ProfileViewModel
                {
                    Id = p.Id,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    Birthday = p.Birthday
                })
                .OrderBy(keySelector);
        }

        public IEnumerable<ProfileViewModel> GetPagedProfiles(int pageSize, int pageNum)
        {
            return _profileRepository
                .GetAll()
                .Skip(pageNum * pageSize)
                .Take(pageSize)
                .Select(p => new ProfileViewModel
                {
                    Id = p.Id,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    Birthday = p.Birthday
                });
        }

        public IEnumerable<ProfileViewModel> GetProfilesFilteredBy(string filter)
        {
            var lowerFilter = filter.ToLower();
            return _profileRepository
                .GetAll()
                .Where(p => p.FirstName.ToLower().Contains(lowerFilter) || p.LastName.ToLower().Contains(lowerFilter))
                .Select(p => new ProfileViewModel
                {
                    Id = p.Id,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    Birthday = p.Birthday
                });
        }

        public IEnumerable<ProfileViewModel> GetProfilesSortedBy<TKey>(Func<ProfileViewModel, TKey> func)
        {
            return _profileRepository
                .GetAll()
                .Select(p => new ProfileViewModel 
                {
                    Id = p.Id,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    Birthday = p.Birthday
                })
                .OrderBy(func);
        }
    }
}
