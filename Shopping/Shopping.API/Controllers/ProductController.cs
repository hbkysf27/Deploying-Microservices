using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Shopping.API.Data;
using Shopping.API.Models;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace Shopping.API.Controllers


    //api controller over here
{
    [ApiController]
    [Route("[Controller]")]
    public class ProductController
    {
        //creating the logger object

        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }

        //get method to get the data from api

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return ProductContext.Products;
        }
    }
}
