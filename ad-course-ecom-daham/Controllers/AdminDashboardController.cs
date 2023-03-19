using ad_course_ecom_daham.Business.Interfaces;
using ad_course_ecom_daham.Models.Product;
using Microsoft.AspNetCore.Mvc;

namespace ad_course_ecom_daham.Controllers
{
    public class AdminDashboardController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly ISeriesService _seriesService;
        List<Series> _seriesList;
        List<Category> _categories;
        public AdminDashboardController(ICategoryService categoryService, ISeriesService seriesService) {
            _categoryService = categoryService;
            _seriesService = seriesService;
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
    }
}
