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
        IEnumerable<ProfileDTO> GetProfilesSortedBy<TKey>(Func<ProfileDTO, TKey> func);
        IEnumerable<ProfileDTO> GetProfilesFilteredBy(string filter);
        IEnumerable<ProfileDTO> GetPagedProfiles(int pageSize, int pageNumber);
        IEnumerable<ProfileDTO> GetProfiles<TKey>(int pageSize, int pageNumber, string filter, Func<ProfileDTO, TKey> keySelector);
        int GetFilteredProfilesCount(string filter);
    }
}
