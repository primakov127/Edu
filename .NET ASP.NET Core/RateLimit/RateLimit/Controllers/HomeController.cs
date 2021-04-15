using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RateLimit.DataAccess.Repositories;
using RateLimit.DataAccess.SeedWork;
using RateLimit.Models;
using RateLimit.SeedWork;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace RateLimit.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProfileService _profileService;

        public HomeController(ILogger<HomeController> logger, IProfileService profileService)
        {
            _logger = logger;
            _profileService = profileService;
        }

        public IActionResult Index(string sortOrder = "FirstName")
        {
            IEnumerable<ProfileViewModel> profiles;

            switch (sortOrder)
            {
                default:
                case "FirstName":
                    profiles = _profileService.GetProfiles(10, 0, "", e => e.FirstName);
                    break;
                case "LastName":
                    profiles = _profileService.GetProfiles(10, 0, "", e => e.LastName);
                    break;
                case "Birthday":
                    profiles = _profileService.GetProfiles(10, 0, "", e => e.Birthday);
                    break;
            }

            return View(profiles);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
