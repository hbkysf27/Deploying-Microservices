using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Shopping.API.Data;
using Shopping.API.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Shopping.API.Controllers


    //api controller over here
{
    [ApiController]
    [Microsoft.AspNetCore.Mvc.Route("[Controller]")]
    public class ProductController : Controller
    {

        private readonly ProductContext _context;
        
        //creating the logger object
        private readonly ILogger<ProductController> _logger;

        public ProductController(ProductContext context, ILogger<ProductController> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger= logger ?? throw new ArgumentNullException(nameof(logger));
        }


        //get method to get the data from api

        [HttpGet]
        public async Task<IEnumerable<Product>> Get()
        {
            return await _context
                         .Products
                         .Find(p=>true)
                         .ToListAsync();
        }
    }
}
