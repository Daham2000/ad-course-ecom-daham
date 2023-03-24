using ad_course_ecom_daham.Business.Interfaces;
using ad_course_ecom_daham.Business.Services;
using ad_course_ecom_daham.Migrations;
using ad_course_ecom_daham.Models;
using ad_course_ecom_daham.Models.CustomerModels;
using ad_course_ecom_daham.Models.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;
using ad_course_ecom_daham.Models.Chart;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace ad_course_ecom_daham.Controllers
{
    public class AdminDashboardController : Controller
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
        public AdminDashboardController(IOrderItemService orderItemService, ICustomerService customerService, IOrderService orderService, IVariationOptionService variationOptionService, IVariationService variationService, ICategoryService categoryService, ISeriesService seriesService, IComputerService computerService) {
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
            for(int i=0; i< _computerList.Count; i++)
            {
                dataPoints.Add(new DataPoint(_computerList[i].cName, _computerList[i].qty));
            }

            ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);
            return View("../Admin/AdminDashboard");
        }

        public IActionResult OpenManageOrders()
        {
            List<string> orderStatus = new List<string>();
            orderStatus.Add("Pending");
            orderStatus.Add("In process");
            orderStatus.Add("Dispatched");
            orderStatus.Add("Delivered");

            _ordersList = _orderService.GetOrders();
            for (int i = 0; i < _ordersList.Count; i++)
            {
                Customer customer = _customerService.GetCustomerById(_ordersList[i].cId);
                _ordersList[i].customer = customer;
                List<OrderItem> orderItemList = _orderItemService.GetOrderItemById(_ordersList[i].oId);
                _ordersList[i].orderItems = orderItemList;
                for (int j = 0; j < _ordersList[i].orderItems.Count; j++)
                {
                    Computer orderComputer = _computerService.GetComputerById(_ordersList[i].orderItems[j].comId);
                    _ordersList[i].orderItems[j].computer = orderComputer;
                }
            }
            ViewBag.orders = _ordersList;
            ViewBag.orderStatus = orderStatus;
            return View("../Order/AdminOrderView");
        }

        public IActionResult ProductMainView()
        {
            try
            {
                _computerList = _computerService.GetComputers();
                _seriesList = _seriesService.GetSeries();
                _categories = _categoryService.GetCategories();
                for (int i = 0; i < _computerList.Count; i++)
                {
                    _computerList[i].seriesName = _seriesList.Where((s) => s.seriesId == _computerList[i].seriesId).FirstOrDefault().seriesName;
                    _computerList[i].cateName = _categories.Where((s) => s.cateId == _computerList[i].cateId).FirstOrDefault().cateName;
                    _computerList[i].normalPrice = decimal.Round(_computerList[i].normalPrice, 2, MidpointRounding.AwayFromZero);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            ViewBag.isManageCategories = false;
            ViewBag.computerList = _computerList;
            ViewBag.isManageSeries = false;
            ViewBag.viewProduct = true;
            return View("../Product/ProductView");
        }

        public IActionResult OpenManageCategories()
        {
            _categories = _categoryService.GetCategories();
            ViewBag.categories = _categories;
            ViewBag.isManageCategories = true;
            ViewBag.viewProduct = false;
            ViewBag.isManageSeries = false;
            return View("../Product/ProductView");
        }
        [HttpPost]
        public IActionResult AddCategory(string categoryName)
        {
            Category category = new Category();
            category.cateName = categoryName;
            _categoryService.AddCategory(category);
            _categories = _categoryService.GetCategories();
            ViewBag.categories = _categories;
            ViewBag.isManageCategories = true;
            ViewBag.viewProduct = false;
            ViewBag.isManageSeries = false;
            return View("../Product/ProductView");
        }

        public IActionResult OpenManageSeries()
        {
            try
            {
                List<Series> series = _seriesService.GetSeries();
                _categories = _categoryService.GetCategories();
                for (int i = 0; i < series.Count; i++)
                {
                    Category category = _categories.Where((c) => c.cateId == series[i].cateId).FirstOrDefault();
                    series[i].categoryName = category.cateName;
                }
                ViewBag.series = series;
                ViewBag.categories = _categories;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
           
            ViewBag.isManageSeries = true;
            ViewBag.viewProduct = false;
            ViewBag.isManageCategories = false;
            return View("../Product/ProductView");
        }

        [HttpPost]
        public IActionResult AddSeries(string seriesName, string categoryName)
        {
            Series newSeries = new Series();
            try
            {
                _categories = _categoryService.GetCategories();
                newSeries.seriesName = seriesName;
                Category cc = _categories.Where((c) => c.cateName == categoryName).FirstOrDefault();
                newSeries.cateId = cc.cateId;
                _seriesService.AddSeries(newSeries);
                List<Series> series = _seriesService.GetSeries();
                for (int i = 0; i < series.Count; i++)
                {
                    Category ca = _categories.Where((c) => c.cateId == series[i].cateId).FirstOrDefault();
                    series[i].categoryName = ca.cateName;
                }

                ViewBag.series = series;
                ViewBag.categories = _categories;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            ViewBag.isManageSeries = true;
            ViewBag.isManageCategories = false;
            ViewBag.viewProduct = false;
            return View("../Product/ProductView");
        }

        public IActionResult OpenAddComputer() {
            try
            {
                _seriesList = _seriesService.GetSeries();
                _categories = _categoryService.GetCategories();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            ViewBag.series = _seriesList;
            ViewBag.categories = _categories;
            ViewBag.isManageSeries = false;
            ViewBag.isManageCategories = false;
            ViewBag.isAddComputer = true;
            ViewBag.viewProduct = false;
            ViewBag.computerStatus = "";
            ViewBag.variationList = _variationList;
            ViewBag.isVariationMode = false;
            return View("../Product/ProductView");
        }

        [HttpPost]
        public IActionResult AddComputer(Computer computer)
        {
            try
            {
                _seriesList = _seriesService.GetSeries();
                _categories = _categoryService.GetCategories();
                Category cc = _categories.Where((c) => c.cateName == computer.cateName).FirstOrDefault();
                computer.cateId = cc.cateId;
                Series ss = _seriesList.Where((c) => c.seriesName == computer.seriesName).FirstOrDefault();
                computer.seriesId = ss.seriesId;

                computer.comId = Guid.NewGuid();
                HttpContext.Session.SetString("comId", computer.comId.ToString());

                _computerService.AddComputer(computer);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            ViewBag.computerStatus = "Computer Added successfull. Now you can add variations.";
            ViewBag.series = _seriesList;
            ViewBag.categories = _categories;
            ViewBag.isManageSeries = false;
            ViewBag.variationList = _variationList;
            ViewBag.isManageCategories = false;
            ViewBag.isAddComputer = true;
            ViewBag.viewProduct = false;
            ViewBag.isVariationMode = false;
            return View("../Product/ProductView");
        }

        [HttpPost]
        public IActionResult AddVariation(string variationName)
        {
            try
            {
                _seriesList = _seriesService.GetSeries();
                _categories = _categoryService.GetCategories();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            ComVariation comVariation = new ComVariation();
            comVariation.comvName = variationName;
            Guid comId = new Guid(HttpContext.Session.GetString("comId"));
            comVariation.comId = comId;
            try
            {
                _variationService.AddVariation(comVariation);
                _variationList = _variationService.GetVariationsByComId(comId);
                for (int i = 0; i < _variationList.Count; i++)
                {
                    _variationList[i].variationOptions = new List<ComVariationOption>();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Computer computer = _computerService.GetComputerById(comId);
            ViewBag.series = _seriesList;
            ViewBag.categories = _categories;
            ViewBag.computer = computer;

            ViewBag.viewProduct = false;
            ViewBag.isManageSeries = false;
            ViewBag.isManageCategories = false;
            ViewBag.isAddComputer = true;
            ViewBag.isVariationMode = true;
            ViewBag.variationList = _variationList;
            return View("../Product/ProductView");
        }

        [HttpPost]
        public IActionResult EditComputer(string comId)
        {
            HttpContext.Session.SetString("comId", comId);
            try
            {
                _categories = _categoryService.GetCategories();
                _seriesList = _seriesService.GetSeries();
                Guid id = new Guid(comId);
                _variationList = _variationService.GetVariationsByComId(id);
                Computer com = _computerService.GetComputerById(id);
                for (int i = 0; i < _variationList.Count; i++)
                {
                    _variationList[i].variationOptions = new List<ComVariationOption>();
                }
                Category category = _categories.Where((c) => c.cateId == com.cateId).FirstOrDefault();
                Series series = _seriesList.Where((c) => c.seriesId == com.seriesId).FirstOrDefault();
                com.cateName = category.cateName;
                com.seriesName = series.seriesName;

                ViewBag.categories = _categories;
                ViewBag.series = _seriesList;
                ViewBag.isManageCategories = true;
                ViewBag.viewProduct = false;
                ViewBag.isManageSeries = false;
                ViewBag.computer = com;

                ViewBag.variationList = _variationList;
                for (int i = 0; i < _variationList.Count; i++)
                {
                    _variationList[i].variationOptions = _variationOptionService.GetVariationsByComId(_variationList[i].comvId);
                    for (int j = 0; j < _variationList[i].variationOptions.Count; j++)
                    {
                        _variationList[i].variationOptions[j].price = decimal.Round(_variationList[i].variationOptions[j].price, 2, MidpointRounding.AwayFromZero);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return View("../Product/EditProductView");
        }

        [HttpPost]
        public IActionResult UpdateComputer(Computer computer)
        {
            try
            {
                _seriesList = _seriesService.GetSeries();
                _categories = _categoryService.GetCategories();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Guid comId = new Guid(HttpContext.Session.GetString("comId"));

            Computer model = _computerService.GetComputerById(comId);
            Category cc = _categories.Where((c) => c.cateName == computer.cateName).FirstOrDefault();
            model.cateId = cc.cateId;
            Series ss = _seriesList.Where((c) => c.seriesName == computer.seriesName).FirstOrDefault();
            model.seriesId = ss.seriesId;

            model.cName = computer.cName;
            model.qty = computer.qty;
            model.normalPrice = computer.normalPrice;

            try
            {
                _computerService.EditComputer(model);

                HttpContext.Session.SetString("comId", computer.comId.ToString());

                ViewBag.computerStatus = "Computer updated successfull. Now you can update variation options.";
                ViewBag.series = _seriesList;
                ViewBag.categories = _categories;

                _variationList = _variationService.GetVariationsByComId(comId);
                for (int i = 0; i < _variationList.Count; i++)
                {
                    _variationList[i].variationOptions = _variationOptionService.GetVariationsByComId(_variationList[i].comvId);
                    for (int j = 0; j < _variationList[i].variationOptions.Count; j++)
                    {
                        _variationList[i].variationOptions[j].price = decimal.Round(_variationList[i].variationOptions[j].price, 2, MidpointRounding.AwayFromZero);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
           
            ViewBag.variationList = _variationList;
            ViewBag.computer = computer;
            return View("../Product/EditProductView");
        }

        [HttpPost]
        public IActionResult AddVariationOptions(string comvopName, string comvId, decimal price, int quantity)
        {
            _seriesList = _seriesService.GetSeries();
            _categories = _categoryService.GetCategories();
            Guid comId = new Guid(HttpContext.Session.GetString("comId"));
            Guid variationId = new Guid(comvId);
            Computer computer = _computerService.GetComputerById(comId);

            ComVariationOption comVariationOption = new ComVariationOption();
            comVariationOption.comvopName = comvopName;
            comVariationOption.price = price;
            comVariationOption.quantity = quantity;
            comVariationOption.comvId = variationId;

            try {
                _variationOptionService.AddVariation(comVariationOption);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Category category = _categories.Where((c) => c.cateId == computer.cateId).FirstOrDefault();
            Series series = _seriesList.Where((c) => c.seriesId == computer.seriesId).FirstOrDefault();
            computer.cateName = category.cateName;
            computer.seriesName = series.seriesName;

            ViewBag.categories = _categories;
            ViewBag.series = _seriesList;
            ViewBag.computer = computer;

            _variationList = _variationService.GetVariationsByComId(comId);
            for (int i = 0; i < _variationList.Count; i++)
            {
                try
                {
                    _variationList[i].variationOptions = _variationOptionService.GetVariationsByComId(_variationList[i].comvId);
                    for (int j = 0; j < _variationList[i].variationOptions.Count; j++)
                    {
                        _variationList[i].variationOptions[j].price = decimal.Round(_variationList[i].variationOptions[j].price, 2, MidpointRounding.AwayFromZero);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            ViewBag.variationList = _variationList;

            return View("../Product/EditProductView");
        }


        [HttpPost]
        public IActionResult UpdateOrderStatus(string oId, string orderStatus)
        {
            try
            {
                Guid orId = new Guid(oId);
                Order order = _orderService.GetOrderById(orId);
                order.status = orderStatus;
                _orderService.EditOrder(order);  
            } catch(Exception e) { 
                Console.WriteLine();
            }

            _ordersList = _orderService.GetOrders();
            for (int i = 0; i < _ordersList.Count; i++)
            {
                _ordersList[i].totalPrice = decimal.Round(_ordersList[i].totalPrice, 2, MidpointRounding.AwayFromZero);
                Customer customer = _customerService.GetCustomerById(_ordersList[i].cId);
                _ordersList[i].customer = customer;
                List<OrderItem> orderItemList = _orderItemService.GetOrderItemById(_ordersList[i].oId);
                _ordersList[i].orderItems = orderItemList;
                for (int j = 0; j < _ordersList[i].orderItems.Count; j++)
                {
                    Computer orderComputer = _computerService.GetComputerById(_ordersList[i].orderItems[j].comId);
                    _ordersList[i].orderItems[j].computer = orderComputer;
                }

                var senderEmail = new MailAddress("courseworkt810@gmail.com");
                var receiverEmail = new MailAddress(customer.cEmail, "Receiver");
                var password = "drmgqctqxnvlagvg";

                var sub = "Your order " + oId.Substring(0,10);
                var body = "Hi " + customer.cName + "\nYour order has been moved to " + orderStatus + " status...";
                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(senderEmail.Address, password),
                    EnableSsl = true
                };
                using (var mess = new MailMessage(senderEmail, receiverEmail)
                {
                    Subject = sub,
                    Body = body
                })
                {
                    smtp.Send(mess);
                }
            }
            ViewBag.orders = _ordersList;

            List<string> orderStatusList = new List<string>();
            orderStatusList.Add("Pending");
            orderStatusList.Add("In process");
            orderStatusList.Add("Dispatched");
            orderStatusList.Add("Delivered");
            ViewBag.orderStatus = orderStatusList;

            return View("../Order/AdminOrderView");
        }
        }

}
