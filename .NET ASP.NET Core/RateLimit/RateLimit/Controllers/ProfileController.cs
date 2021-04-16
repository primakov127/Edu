using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RateLimit.Attributes;
using RateLimit.DataAccess.Repositories;
using RateLimit.DataAccess.SeedWork;
using RateLimit.DataTransferObjects;
using RateLimit.Models;
using RateLimit.SeedWork;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RateLimit.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IProfileService _profileService;
        private readonly int pageSize = 5;

        public ProfileController(IProfileService profileService)
        {
            _profileService = profileService;
        }

        [RequestRateLimit(5)]
        public async Task<IActionResult> Index(string sortOrder, string searchString, int pageNumber = 1)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["CurrentFilter"] = searchString;
            IEnumerable<ProfileDTO> profiles;
            int profilesCount;

            if (searchString == null)
            {
                searchString = String.Empty;
            }
            
            switch (sortOrder)
            {
                default:
                case "FirstName":
                    profiles = await _profileService.GetProfiles(pageSize, pageNumber, searchString, e => e.FirstName);
                    break;
                case "LastName":
                    profiles = await _profileService.GetProfiles(pageSize, pageNumber, searchString, e => e.LastName);
                    break;
                case "Birthday":
                    profiles = await _profileService.GetProfiles(pageSize, pageNumber, searchString, e => e.Birthday);
                    break;
            }
            profilesCount = await _profileService.GetFilteredProfilesCount(searchString);

            return View("Profile", new ProfileListViewModel(profiles, profilesCount, pageNumber, pageSize));
        }
    }
}
