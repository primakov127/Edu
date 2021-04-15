using RateLimit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RateLimit.SeedWork
{
    public interface IProfileService
    {
        IEnumerable<ProfileViewModel> GetProfilesSortedBy<TKey>(Func<ProfileViewModel, TKey> func);
        IEnumerable<ProfileViewModel> GetProfilesFilteredBy(string filter);
        IEnumerable<ProfileViewModel> GetPagedProfiles(int pageSize, int pageNum);
        IEnumerable<ProfileViewModel> GetProfiles<TKey>(int pageSize, int pageNum, string filter, Func<ProfileViewModel, TKey> keySelector);
    }
}
