using ad_course_ecom_daham.Business.Interfaces;
using ad_course_ecom_daham.Data;
using ad_course_ecom_daham.Models.Product;
using Microsoft.EntityFrameworkCore;

namespace ad_course_ecom_daham.Business.Services
{
    public class VariationService : IVariationService
    {
        ApplicationDbContext _context;
        public VariationService(ApplicationDbContext context)
        {
            _context = context;
        }
        void IVariationService.AddVariation(ComVariation model)
        {
            model.comvId = Guid.NewGuid();
            _context.Add(model);
            _context.SaveChanges();
        }

        void IVariationService.DeleteVariation(Guid? id)
        {
            throw new NotImplementedException();
        }

        void IVariationService.EditVariation(ComVariation model)
        {
            throw new NotImplementedException();
        }

        ComVariation IVariationService.GetVariationById(Guid? id)
        {
            throw new NotImplementedException();
        }

        List<ComVariation> IVariationService.GetVariations()
        {
            return _context.comVariations.ToList();
        }
    }
}
