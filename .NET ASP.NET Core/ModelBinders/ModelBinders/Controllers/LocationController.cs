using Microsoft.AspNetCore.Mvc;
using ModelBinders.ModelBinders;
using ModelBinders.Models;
using System.Collections.Generic;
using System.Linq;

namespace ModelBinders.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        public ActionResult Get([ModelBinder(typeof(CoordsModelBinder))]IEnumerable<int> coords)
        {
            if (coords.Count() < 3)
            {
                return BadRequest();
            }

            var result = new Point
            {
                X = coords.ElementAt(0),
                Y = coords.ElementAt(1),
                Z = coords.ElementAt(2)
            };

            return Ok(result);
        }
    }
}
