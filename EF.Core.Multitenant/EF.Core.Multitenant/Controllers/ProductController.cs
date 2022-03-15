using Microsoft.AspNetCore.Mvc;
using Multitenant.Domain;
using Multitenant.Infraestructure.Data;

namespace Multitenant.API.Controllers
{
    [ApiController]
    [Route("{tenant}/[Controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Product> Get([FromServices] ApplicationContext db)
        {
            var products = db.Products.ToArray();

            return products;
        }
    }
}
