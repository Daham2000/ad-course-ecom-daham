using ad_course_ecom_daham.Business.Interfaces;
using ad_course_ecom_daham.Business.Services;
using ad_course_ecom_daham.Models;
using ad_course_ecom_daham.Models.Chart;
using ad_course_ecom_daham.Models.CustomerModels;
using ad_course_ecom_daham.Models.Product;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace ad_course_ecom_daham.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IComputerService _computerService;
        private readonly IVariationService _variationService;
        private readonly IVariationOptionService _variationOptionService;

        public HomeController(ILogger<HomeController> logger, IComputerService computerService, IVariationService variationService, IVariationOptionService variationOptionService)
        {
            _logger = logger;
            _computerService = computerService;
            _variationService = variationService;
            _variationOptionService = variationOptionService;
        }

        public IActionResult Index()
        {
            try
            {
                List<Computer> computers = _computerService.GetComputers();
                ViewBag.computers = computers;
                return View("../Home/Index");
            }
            catch (Exception e)
            {
                ViewBag.errorLogin = "Email or password you entered is incorrect. ";
                Console.WriteLine(e.ToString());
            }
            return View("../Home/Index");
        }

        public IActionResult ViewSingleProduct(string comId)
        {
            Guid id = new Guid(comId);
            Computer com = _computerService.GetComputerById(id);
            List<ComVariation> variations = _variationService.GetVariationsByComId(com.comId);
            for(int i = 0; i < variations.Count; i++)
            {
                var variation = variations[i];
                List<ComVariationOption> comVariationOptions = _variationOptionService.GetVariationsByComId(variation.comvId);
                variations[i].variationOptions = comVariationOptions;
            }
            ViewBag.computer = com;
            ViewBag.variationList = variations;
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