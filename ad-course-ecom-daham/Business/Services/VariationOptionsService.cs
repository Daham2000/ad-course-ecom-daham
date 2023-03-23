using ad_course_ecom_daham.Business.Interfaces;
using ad_course_ecom_daham.Data;
using ad_course_ecom_daham.Models.Product;

namespace ad_course_ecom_daham.Business.Services
{
    public class VariationOptionsService : IVariationOptionService
    {
        ApplicationDbContext _context;
        public VariationOptionsService(ApplicationDbContext context)
        {
            _context = context;
        }
        void IVariationOptionService.AddVariation(ComVariationOption model)
        {
            model.comvId = Guid.NewGuid();
            _context.Add(model);
            _context.SaveChanges();
        }

        void IVariationOptionService.DeleteVariation(Guid? id)
        {
            throw new NotImplementedException();
        }

        void IVariationOptionService.EditVariation(ComVariationOption model)
        {
            throw new NotImplementedException();
        }

        ComVariationOption IVariationOptionService.GetVariationById(Guid? id)
        {
            throw new NotImplementedException();
        }

        List<ComVariationOption> IVariationOptionService.GetVariations()
        {
            throw new NotImplementedException();
        }

        List<ComVariationOption> IVariationOptionService.GetVariationsByComId(Guid? comvId)
        {
            return _context.comVariationOptions.Where((v) => v.comvId == comvId).ToList();
        }
    }
}
