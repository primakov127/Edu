using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelBinders.ModelBinders;
using ModelBinders.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModelBinders.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        [HttpGet("{personId}")]
        public ActionResult Get([ModelBinder(typeof(PersonIdModelBinder))]Guid personId)
        {
            var person = new Person { Id = personId, Name = "Max" };
            return Ok(person);
        }
    }
}
