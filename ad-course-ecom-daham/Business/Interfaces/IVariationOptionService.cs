using ad_course_ecom_daham.Models.Product;

namespace ad_course_ecom_daham.Business.Interfaces
{
    public interface IVariationOptionService
    {
        void AddVariation(ComVariationOption model);
        List<ComVariationOption> GetVariations();
        List<ComVariationOption> GetVariationsByComId(Guid? comvId);
        ComVariationOption GetVariationById(Guid? id);
        void EditVariation(ComVariationOption model);
        void DeleteVariation(Guid? id);
    }
}
