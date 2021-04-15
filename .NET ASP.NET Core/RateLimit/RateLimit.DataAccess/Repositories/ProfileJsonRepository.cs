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

        public ProfileJsonRepository(string jsonFilePath)
        {
            _json = File.ReadAllText(jsonFilePath);
            _profiles = JsonConvert.DeserializeObject<IEnumerable<Profile>>(_json);
        }

        public IEnumerable<Profile> GetAll()
        {
            return _profiles;
        }
    }
}
