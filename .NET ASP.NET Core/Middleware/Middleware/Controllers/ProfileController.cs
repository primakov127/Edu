using Microsoft.AspNetCore.Mvc;
using Middleware.Models;
using Middleware.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Middleware.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly ProfileService _profileService;

        public ProfileController(ProfileService profileService)
        {
            _profileService = profileService;
        }

        [HttpGet]
        public async Task<IEnumerable<Profile>> Get()
        {
            return await _profileService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<Profile> Get(int id)
        {
            return await _profileService.GetByIdAsync(id);
        }

        [HttpPost]
        public async Task Post(string name)
        {
            await _profileService.AddAsync(name);
        }

        [HttpPut("{id}")]
        public async Task Put(int id, string name)
        {
            await _profileService.UpdateAsync(id, name);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _profileService.DeleteAsync(id);
        }
    }
}
