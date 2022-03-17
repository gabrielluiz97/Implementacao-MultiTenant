using Microsoft.AspNetCore.Mvc;
using Multitenant.Domain;
using Multitenant.Infraestructure.Data;

namespace Multitenant.API.Controllers
{
    [ApiController]
    [Route("{tenant}/[Controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationContext _db;

        public ProductController(ApplicationContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            var products = _db.Products.ToArray();

            return products;
        }
    }
}
