using Newtonsoft.Json;
using RateLimit.DataAccess.Models;
using RateLimit.DataAccess.SeedWork;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateLimit.DataAccess.Repositories
{
    public class ProfileJsonRepository : IProfileRepository
    {
        private readonly string _json;
        private readonly IEnumerable<Profile> _profiles;
        private readonly string _jsonFilePath;

        public ProfileJsonRepository(string jsonFilePath)
        {
            _jsonFilePath = jsonFilePath;
        }

        public async Task<IEnumerable<Profile>> GetAllAsync()
        {
            using (var fileStream = new FileStream(_jsonFilePath, FileMode.OpenOrCreate))
            {
                var readBytes = new Byte[fileStream.Length];

                await fileStream.ReadAsync(readBytes);

                var json = Encoding.UTF8.GetString(readBytes);
                var profiles = JsonConvert.DeserializeObject<IEnumerable<Profile>>(json);

                return profiles;
            }
        }
    }
}
