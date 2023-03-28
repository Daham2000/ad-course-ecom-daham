using ad_course_ecom_daham.Models.Product;

namespace ad_course_ecom_daham.Business.Interfaces
{
    public interface ICategoryService
    {
        public void AddCategory(Category model);
        public List<Category> GetCategories();
        public Category GetCategoryById(Guid? id);
        public void EditCategory(Category model);
        public void DeleteCategory(Guid? id);
    }
}
