using ad_course_ecom_daham.Models.Chart;
using ad_course_ecom_daham.Models.CustomerModels;
using ad_course_ecom_daham.Models.Product;
using ad_course_ecom_daham.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ad_course_ecom_daham.Business.Interfaces;

namespace ad_course_ecom_daham.Controllers
{
    public class AuthController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly ISeriesService _seriesService;
        private readonly IComputerService _computerService;
        private readonly IVariationService _variationService;
        private readonly IVariationOptionService _variationOptionService;
        private readonly IOrderService _orderService;
        private readonly IOrderItemService _orderItemService;
        private readonly ICustomerService _customerService;
        List<Series> _seriesList;
        List<Category> _categories;
        List<Computer> _computerList;
        List<Order> _ordersList;
        List<Customer> _customersList;
        List<ComVariation> _variationList = new List<ComVariation>();
        public AuthController(IOrderItemService orderItemService, ICustomerService customerService, IOrderService orderService, IVariationOptionService variationOptionService, IVariationService variationService, ICategoryService categoryService, ISeriesService seriesService, IComputerService computerService)
        {
            _categoryService = categoryService;
            _seriesService = seriesService;
            _computerService = computerService;
            _variationService = variationService;
            _variationOptionService = variationOptionService;
            _orderService = orderService;
            _orderItemService = orderItemService;
            _customerService = customerService;
        }
        public IActionResult Index()
        {
            return View("../Auth/LoginView");
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            try {
                if(email == "admin@gmail.com")
                {
                    _ordersList = _orderService.GetOrders();
                    _customersList = _customerService.GetCustomers();
                    for (int i = 0; i < _ordersList.Count; i++)
                    {
                        Customer customer = _customerService.GetCustomerById(_ordersList[i].cId);
                        _ordersList[i].customer = customer;
                        _ordersList[i].totalPrice = decimal.Round(_ordersList[i].totalPrice, 2, MidpointRounding.AwayFromZero);
                        List<OrderItem> orderItemList = _orderItemService.GetOrderItemById(_ordersList[i].oId);
                        _ordersList[i].orderItems = orderItemList;
                        for (int j = 0; j < _ordersList[i].orderItems.Count; j++)
                        {
                            Computer orderComputer = _computerService.GetComputerById(_ordersList[i].orderItems[j].comId);
                            _ordersList[i].orderItems[j].computer = orderComputer;
                        }
                    }
                    ViewBag.orders = _ordersList;
                    ViewBag.customers = _customersList;
                    ViewBag.isManageCategories = false;

                    List<DataPoint> dataPoints = new List<DataPoint>();
                    _computerList = _computerService.GetComputers();
                    for (int i = 0; i < _computerList.Count; i++)
                    {
                        dataPoints.Add(new DataPoint(_computerList[i].cName, _computerList[i].qty));
                    }

                    ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);
                    ViewBag.errorLogin = "";
                    return View("../Admin/AdminDashboard");
                }
                else
                {
                    return View("../Home/Index");
                }
            }
            catch(Exception e) {
                ViewBag.errorLogin = "Email or password you entered is incorrect. ";
                Console.WriteLine(e.ToString());
            }
            ViewBag.errorLogin = "Email or password you entered is incorrect. ";
            return View("../Auth/LoginView");
        }
    }
}
