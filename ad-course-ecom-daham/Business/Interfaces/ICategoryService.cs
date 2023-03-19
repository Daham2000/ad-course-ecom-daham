using ad_course_ecom_daham.Models.Product;

namespace ad_course_ecom_daham.Business.Interfaces
{
    public interface ICategoryService
    {
        void AddCategory(Category model);
        List<Category> GetCategories();
        Category GetCategoryById(Guid? id);
        void EditCategory(Category model);
        void DeleteCategory(Guid? id);
    }
}
