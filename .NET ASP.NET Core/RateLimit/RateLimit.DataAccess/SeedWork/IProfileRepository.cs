using RateLimit.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateLimit.DataAccess.SeedWork
{
    public interface IProfileRepository
    {
        IEnumerable<Profile> GetAll();
    }
}
