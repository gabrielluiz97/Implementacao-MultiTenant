using Microsoft.AspNetCore.Mvc;
using Multitenant.Domain;
using Multitenant.Infraestructure.Data;

namespace Multitenant.API.Controllers
{
    [ApiController]
    [Route("{tenant}/[Controller]")]
    public class PersonController : ControllerBase
    {
        private readonly ApplicationContext _db;

        public PersonController(ApplicationContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IEnumerable<Person> Get()
        {
            var people = _db.People.ToArray();

            return people;
        }
    }
}
