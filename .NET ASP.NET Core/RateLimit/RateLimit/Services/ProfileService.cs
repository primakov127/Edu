using RateLimit.DataAccess.SeedWork;
using RateLimit.DataTransferObjects;
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

        public IEnumerable<ProfileDTO> GetProfiles<TKey>(int pageSize, int pageNumber, string filter, Func<ProfileDTO, TKey> keySelector)
        {
            var lowerFilter = filter.ToLower();
            return _profileRepository
                .GetAll()
                .Where(p => p.FirstName.ToLower().Contains(lowerFilter) || p.LastName.ToLower().Contains(lowerFilter))
                .Select(p => new ProfileDTO
                {
                    Id = p.Id,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    Birthday = p.Birthday
                })
                .OrderBy(keySelector)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);
        }

        public IEnumerable<ProfileDTO> GetPagedProfiles(int pageSize, int pageNumber)
        {
            return _profileRepository
                .GetAll()
                .Skip(pageNumber * pageSize)
                .Take(pageSize)
                .Select(p => new ProfileDTO
                {
                    Id = p.Id,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    Birthday = p.Birthday
                });
        }

        public IEnumerable<ProfileDTO> GetProfilesFilteredBy(string filter)
        {
            var lowerFilter = filter.ToLower();
            return _profileRepository
                .GetAll()
                .Where(p => p.FirstName.ToLower().Contains(lowerFilter) || p.LastName.ToLower().Contains(lowerFilter))
                .Select(p => new ProfileDTO
                {
                    Id = p.Id,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    Birthday = p.Birthday
                });
        }

        public IEnumerable<ProfileDTO> GetProfilesSortedBy<TKey>(Func<ProfileDTO, TKey> func)
        {
            return _profileRepository
                .GetAll()
                .Select(p => new ProfileDTO
                {
                    Id = p.Id,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    Birthday = p.Birthday
                })
                .OrderBy(func);
        }

        public int GetFilteredProfilesCount(string filter)
        {
            return _profileRepository
                .GetAll().Where(p => p.FirstName.ToLower().Contains(filter) || p.LastName.ToLower().Contains(filter))
                .Count();
        }
    }
}
