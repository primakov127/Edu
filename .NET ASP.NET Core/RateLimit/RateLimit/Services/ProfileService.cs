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

        public async Task<IEnumerable<ProfileDTO>> GetProfiles<TKey>(int pageSize, int pageNumber, string filter, Func<ProfileDTO, TKey> keySelector)
        {
            var lowerFilter = filter.ToLower();
            var profiles = await _profileRepository.GetAllAsync();

            return profiles
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

        public async Task<IEnumerable<ProfileDTO>> GetPagedProfiles(int pageSize, int pageNumber)
        {
            var profiles = await _profileRepository.GetAllAsync();

            return profiles
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

        public async Task<IEnumerable<ProfileDTO>> GetProfilesFilteredBy(string filter)
        {
            var lowerFilter = filter.ToLower();
            var profiles = await _profileRepository.GetAllAsync();

            return profiles
                .Where(p => p.FirstName.ToLower().Contains(lowerFilter) || p.LastName.ToLower().Contains(lowerFilter))
                .Select(p => new ProfileDTO
                {
                    Id = p.Id,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    Birthday = p.Birthday
                });
        }

        public async Task<IEnumerable<ProfileDTO>> GetProfilesSortedBy<TKey>(Func<ProfileDTO, TKey> func)
        {
            var profiles = await _profileRepository.GetAllAsync();

            return profiles
                .Select(p => new ProfileDTO
                {
                    Id = p.Id,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    Birthday = p.Birthday
                })
                .OrderBy(func);
        }

        public async Task<int> GetFilteredProfilesCount(string filter)
        {
            var profiles = await _profileRepository.GetAllAsync();

            return profiles
                .Where(p => p.FirstName.ToLower().Contains(filter) || p.LastName.ToLower().Contains(filter))
                .Count();
        }
    }
}
