using ad_course_ecom_daham.Models.Product;

namespace ad_course_ecom_daham.Business.Interfaces
{
    public interface IVariationOptionService
    {
        public void AddVariation(ComVariationOption model);
        public List<ComVariationOption> GetVariations();
        public List<ComVariationOption> GetVariationsByComId(Guid? comvId);
        public ComVariationOption GetVariationById(Guid? id);
        public void EditVariation(ComVariationOption model);
        public void DeleteVariation(Guid? id);
    }
}
