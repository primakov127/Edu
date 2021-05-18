using RateLimit.DataTransferObjects;
using RateLimit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RateLimit.SeedWork
{
    public interface IProfileService
    {
        Task<IEnumerable<ProfileDTO>> GetProfilesSortedBy<TKey>(Func<ProfileDTO, TKey> func);
        Task<IEnumerable<ProfileDTO>> GetProfilesFilteredBy(string filter);
        Task<IEnumerable<ProfileDTO>> GetPagedProfiles(int pageSize, int pageNumber);
        Task<IEnumerable<ProfileDTO>> GetProfiles<TKey>(int pageSize, int pageNumber, string filter, Func<ProfileDTO, TKey> keySelector);
        Task<int> GetFilteredProfilesCount(string filter);
    }
}
