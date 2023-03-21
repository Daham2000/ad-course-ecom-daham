using ad_course_ecom_daham.Business.Interfaces;
using ad_course_ecom_daham.Models.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ad_course_ecom_daham.Controllers
{
    public class AdminDashboardController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly ISeriesService _seriesService;
        private readonly IComputerService _computerService;
        private readonly IVariationService _variationService;
        List<Series> _seriesList;
        List<Category> _categories;
        List<ComVariation> _variationList = new List<ComVariation>();
        public AdminDashboardController(IVariationService variationService, ICategoryService categoryService, ISeriesService seriesService, IComputerService computerService) {
            _categoryService = categoryService;
            _seriesService = seriesService;
            _computerService = computerService;
            _variationService = variationService;
        }
        public IActionResult Index()
        {
            ViewBag.isManageCategories = false;
            return View("../Admin/AdminDashboard");
        }

        public IActionResult ProductMainView()
        {
            ViewBag.isManageCategories = false;
            ViewBag.isManageSeries = false;
            return View("../Product/ProductView");
        }

        public IActionResult OpenManageCategories()
        {
            _categories = _categoryService.GetCategories();
            ViewBag.categories = _categories;
            ViewBag.isManageCategories = true;
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
            ViewBag.isManageSeries = false;
            return View("../Product/ProductView");
        }

        public IActionResult OpenManageSeries()
        {
            List<Series> series = _seriesService.GetSeries();
            _categories  = _categoryService.GetCategories();
            for(int i = 0; i < series.Count; i++)
            {
                Category category = _categories.Where((c) => c.cateId == series[i].cateId).FirstOrDefault();
                series[i].categoryName = category.cateName;
            }
            ViewBag.series = series;
            ViewBag.categories = _categories;
            ViewBag.isManageSeries = true;
            ViewBag.isManageCategories = false;
            return View("../Product/ProductView");
        }

        [HttpPost]
        public IActionResult AddSeries(string seriesName, string categoryName)
        {
            Series newSeries = new Series();
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
            ViewBag.isManageSeries = true;
            ViewBag.isManageCategories = false;
            return View("../Product/ProductView");
        }

        public IActionResult OpenAddComputer() {
            _seriesList = _seriesService.GetSeries();
            _categories = _categoryService.GetCategories();
            ViewBag.series = _seriesList;
            ViewBag.categories = _categories;
            ViewBag.isManageSeries = false;
            ViewBag.isManageCategories = false;
            ViewBag.isAddComputer = true;
            ViewBag.computerStatus = "";
            ViewBag.variationList = _variationList;
            ViewBag.isVariationMode = false;
            return View("../Product/ProductView");
        }

        [HttpPost]
        public IActionResult AddComputer(Computer computer)
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

            ViewBag.computerStatus = "Computer Added successfull. Now you can add variations.";
            ViewBag.series = _seriesList;
            ViewBag.categories = _categories;
            ViewBag.isManageSeries = false;
            ViewBag.variationList = _variationList;
            ViewBag.isManageCategories = false;
            ViewBag.isAddComputer = true;
            ViewBag.isVariationMode = false;
            return View("../Product/ProductView");
        }

        [HttpPost]
        public IActionResult AddVariation(string variationName)
        {
            _seriesList = _seriesService.GetSeries();
            _categories = _categoryService.GetCategories();
            ComVariation comVariation = new ComVariation();
            comVariation.comvName = variationName;
            Guid comId = new Guid(HttpContext.Session.GetString("comId"));
            comVariation.comId = comId;
            _variationService.AddVariation(comVariation);
            _variationList = _variationService.GetVariationsByComId(comId);
            Computer computer = _computerService.GetComputerById(comId);
            ViewBag.series = _seriesList;
            ViewBag.categories = _categories;
            ViewBag.computer = computer;

            ViewBag.isManageSeries = false;
            ViewBag.isManageCategories = false;
            ViewBag.isAddComputer = true;
            ViewBag.isVariationMode = true;
            ViewBag.variationList = _variationList;
            return View("../Product/ProductView");
        }
    }
}
