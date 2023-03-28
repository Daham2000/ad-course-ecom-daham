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

        /* Manage to add new categories to the database. Only one category at a time. */
        public void AddCategory(Category model)
        {
            model.cateId = Guid.NewGuid();
            _context.Add(model);
            _context.SaveChanges();
        }

        /* Design to delete category one by one. This method needs to call each time to delete a category. */
        public void DeleteCategory(Guid? id)
        {
            throw new NotImplementedException();
        }

        /* Edit a category usinf Category model object. */
        public void EditCategory(Category model)
        {
            throw new NotImplementedException();
        }

        /* Get all categories as a list. */
        public List<Category> GetCategories()
        {
            List<Category> categories = _context.categories.ToList();
            return categories;
        }

        /* Get a category using category id. */
        public Category GetCategoryById(Guid? id)
        {
            throw new NotImplementedException();
        }
    }
}
