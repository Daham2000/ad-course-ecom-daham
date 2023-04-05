using ad_course_ecom_daham.Business.Interfaces;
using ad_course_ecom_daham.Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace ad_course_ecom_daham.Controllers
{
    public class OrderController : Controller
    {
        private readonly IComputerService _computerService;
        private readonly IVariationService _variationService;
        private readonly IVariationOptionService _variationOptionService;
        private readonly ICustomerService _customerService;

        public OrderController(IComputerService computerService, IVariationService variationService, 
            IVariationOptionService variationOptionService, ICustomerService customerService)
        {
            _computerService = computerService;
            _variationService = variationService;
            _variationOptionService = variationOptionService;
            _customerService = customerService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CheckoutAction(string comId, int qty)
        {
            return View();
        }
    }
}
