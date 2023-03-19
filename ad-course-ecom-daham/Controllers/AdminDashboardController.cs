using ad_course_ecom_daham.Business.Interfaces;
using ad_course_ecom_daham.Models.Product;
using Microsoft.AspNetCore.Mvc;

namespace ad_course_ecom_daham.Controllers
{
    public class AdminDashboardController : Controller
    {
        private readonly ICategoryService _categoryService;
        public AdminDashboardController(ICategoryService categoryService) {
            _categoryService = categoryService;
        }
        public IActionResult Index()
        {
            ViewBag.isManageCategories = false;
            return View("../Admin/AdminDashboard");
        }

        public IActionResult ProductMainView()
        {
            ViewBag.isManageCategories = false;
            return View("../Product/ProductView");
        }

        public IActionResult OpenManageCategories()
        {
            List<Category> categories = _categoryService.GetCategories();
            ViewBag.categories = categories;
            ViewBag.isManageCategories = true;
            return View("../Product/ProductView");
        }
        [HttpPost]
        public IActionResult AddCategory(string categoryName)
        {
            Category category = new Category();
            category.cateName = categoryName;
            _categoryService.AddCategory(category);
            List<Category> categories = _categoryService.GetCategories();
            ViewBag.categories = categories;
            ViewBag.isManageCategories = true;
            return View("../Product/ProductView");
        }
    }
}
