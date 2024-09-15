using Middleware.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Middleware.Services
{
    public class ProfileService
    {
        private List<Profile> _profiles;
        private Random _rand;

        private int Delay
        {
            get
            {
                return _rand.Next(1000, 10000);
            }
        }

        public ProfileService()
        {
            _rand = new Random();
            _profiles = new List<Profile>
            {
                new Profile { Id = 1, Name = "Max" },
                new Profile { Id = 2, Name = "Sergey" },
                new Profile { Id = 3, Name = "Anton" },
                new Profile { Id = 4, Name = "Denis" },
                new Profile { Id = 5, Name = "Katya" },
                new Profile { Id = 6, Name = "Lisa" },
                new Profile { Id = 7, Name = "Andrey" },
                new Profile { Id = 8, Name = "James" },
                new Profile { Id = 9, Name = "Jhon" },
            };
        }

        public async Task<IEnumerable<Profile>> GetAllAsync()
        {
            await Task.Delay(Delay);

            return _profiles;
        }

        public async Task<Profile> GetByIdAsync(int id)
        {
            await Task.Delay(Delay);

            return _profiles.Find(p => p.Id == id);
        }

        public async Task AddAsync(string name)
        {
            await Task.Delay(Delay);

            var newProfile = new Profile
            {
                Id = _profiles.Select(p => p.Id).Max() + 1,
                Name = name
            };

            _profiles.Add(newProfile);
        }

        public async Task UpdateAsync(int id, string name)
        {
            await Task.Delay(Delay);

            var profile = _profiles.Find(p => p.Id == id);
            if (profile != null)
            {
                profile.Name = name;
            }
        }

        public async Task DeleteAsync(int id)
        {
            await Task.Delay(Delay);

            var profile = _profiles.Find(p => p.Id == id);
            if (profile != null)
            {
                _profiles.Remove(profile);
            }
        }
    }
}
