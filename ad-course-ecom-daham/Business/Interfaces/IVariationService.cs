using ad_course_ecom_daham.Models.Product;

namespace ad_course_ecom_daham.Business.Interfaces
{
    public interface IVariationService
    {
        void AddVariation(ComVariation model);
        List<ComVariation> GetVariations();
        ComVariation GetVariationById(Guid? id);
        void EditVariation(ComVariation model);
        void DeleteVariation(Guid? id);
    }
}
