using RateLimit.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RateLimit.Models
{
    public class ProfileListViewModel
    {
        public IEnumerable<ProfileDTO> Profiles { get; set; }
        public int CurrentPageNumber { get; set; }
        public int TotalPagesNumber { get; set; }

        public bool HasPreviousPage
        {
            get
            {
                return (CurrentPageNumber > 1);
            }
        }

        public bool HasNextPage
        {
            get
            {
                return (CurrentPageNumber < TotalPagesNumber);
            }
        }

        public ProfileListViewModel(IEnumerable<ProfileDTO> profiles, int profilesCount, int currentPageNumber, int pageSize)
        {
            Profiles = profiles;
            TotalPagesNumber = (int)Math.Ceiling(profilesCount / (decimal)pageSize);
            CurrentPageNumber = currentPageNumber;
        }
    }
}
