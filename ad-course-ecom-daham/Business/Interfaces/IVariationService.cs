using ad_course_ecom_daham.Models.Product;

namespace ad_course_ecom_daham.Business.Interfaces
{
    public interface IVariationService
    {
        public void AddVariation(ComVariation model);
        public List<ComVariation> GetVariations();
        public List<ComVariation> GetVariationsByComId(Guid? comId);
        public ComVariation GetVariationById(Guid? id);
        public void EditVariation(ComVariation model);
        public void DeleteVariation(Guid? id);
    }
}
