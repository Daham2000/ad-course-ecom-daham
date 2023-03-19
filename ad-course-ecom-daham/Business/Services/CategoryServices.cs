using ad_course_ecom_daham.Business.Interfaces;
using ad_course_ecom_daham.Data;
using ad_course_ecom_daham.Models.Product;

namespace ad_course_ecom_daham.Business.Services
{
    public class CategoryServices : ICategoryService
    {
        ApplicationDbContext _context;
        public CategoryServices(ApplicationDbContext context) {
            _context = context;
        }

        void ICategoryService.AddCategory(Category model)
        {
            model.cateId = Guid.NewGuid();
            _context.Add(model);
            _context.SaveChanges();
        }

        void ICategoryService.DeleteCategory(Guid? id)
        {
            throw new NotImplementedException();
        }

        void ICategoryService.EditCategory(Category model)
        {
            throw new NotImplementedException();
        }

        List<Category> ICategoryService.GetCategories()
        {
            List<Category> categories = _context.categories.ToList();
            return categories;
        }

        Category ICategoryService.GetCategoryById(Guid? id)
        {
            throw new NotImplementedException();
        }
    }
}
