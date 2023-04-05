using ad_course_ecom_daham.Models.Chart;
using ad_course_ecom_daham.Models.CustomerModels;
using ad_course_ecom_daham.Models.Product;
using ad_course_ecom_daham.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ad_course_ecom_daham.Business.Interfaces;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;

namespace ad_course_ecom_daham.Controllers.AdminReport
{
    public class AdminOrderReport : Controller
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
        public AdminOrderReport(IOrderItemService orderItemService, ICustomerService customerService, IOrderService orderService, IVariationOptionService variationOptionService, IVariationService variationService, ICategoryService categoryService, ISeriesService seriesService, IComputerService computerService)
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

        public IActionResult GenarateOrderReport()
        {
            _ordersList = _orderService.GetOrders();
            using (var stream = new MemoryStream())
            {
                using (var writer = new PdfWriter(stream))
                {
                    using (var pdf = new PdfDocument(writer))
                    {
                        var document = new Document(pdf);

                        if (_ordersList.Count != 0)
                        {
                            //Create report title and subtitles
                            document.Add(new Paragraph("Orders Report").SetTextAlignment(TextAlignment.CENTER).SetFontSize(18));
                            document.Add(new Paragraph("Date: " + DateTime.Now.ToString("dd/MM/yyyy")).SetTextAlignment(TextAlignment.CENTER).SetFontSize(10));

                            //Create report table
                            var table = new Table(new float[] { 1, 1, 1, 1, 1});
                            table.AddHeaderCell(new Cell().Add(new Paragraph("#")));
                            table.AddHeaderCell(new Cell().Add(new Paragraph("Order ID")));
                            table.AddHeaderCell(new Cell().Add(new Paragraph("Customer Name")));
                            table.AddHeaderCell(new Cell().Add(new Paragraph("Order Total")));
                            table.AddHeaderCell(new Cell().Add(new Paragraph("Order Quantity")));

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
                                table.AddCell(new Cell().Add(new Paragraph((i+1).ToString())));
                                table.AddCell(new Cell().Add(new Paragraph(_ordersList[i].oId.ToString())));
                                table.AddCell(new Cell().Add(new Paragraph(customer.cName)));
                                table.AddCell(new Cell().Add(new Paragraph(_ordersList[i].totalPrice.ToString())));
                                table.AddCell(new Cell().Add(new Paragraph(_ordersList[i].totalQty.ToString())));
                            }
                            document.Add(table);
                        }
                        else
                        {
                            document.Add(new Paragraph("No orders data!").SetTextAlignment(TextAlignment.CENTER).SetFontSize(18));
                        }

                        document.Close();
                    }
                }
                return File(stream.ToArray(), "application/pdf", "Order Report.pdf");
            }

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
            return View("../Admin/AdminDashboard");
        }
    }
}
