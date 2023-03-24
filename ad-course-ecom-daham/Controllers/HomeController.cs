using ad_course_ecom_daham.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ad_course_ecom_daham.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ViewSingleProduct()
        {
            return View("../Product/SingleProductView");
        }

        public IActionResult Privacy()
        {
            return View("../Product/ProductView");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}