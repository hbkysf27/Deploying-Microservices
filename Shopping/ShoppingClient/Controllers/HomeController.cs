using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShoppingClient.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ShoppingClient.Controllers;
using System.Net.Http;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace ShoppingClient.Controllers
{
    public class HomeController : Controller
    {

        private readonly HttpClient _httpClient;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IHttpClientFactory HttpClientFactory, ILogger<HomeController> logger)
        {
           
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _httpClient = HttpClientFactory.CreateClient("ShoppingAPIClient");
        }

        public async Task <IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("/product");
            var content =await response.Content.ReadAsStringAsync();
            var productList = JsonConvert.DeserializeObject<IEnumerable<Product>>(content);


            return View(productList);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
