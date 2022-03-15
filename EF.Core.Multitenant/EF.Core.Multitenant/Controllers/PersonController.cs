using Microsoft.AspNetCore.Mvc;
using Multitenant.Domain;
using Multitenant.Infraestructure.Data;

namespace Multitenant.API.Controllers
{
    [ApiController]
    [Route("{tenant}/[Controller]")]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;

        public PersonController(ILogger<PersonController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Person> Get([FromServices]ApplicationContext db)
        {
            var people = db.People.ToArray();

            return people;
        }
    }
}
