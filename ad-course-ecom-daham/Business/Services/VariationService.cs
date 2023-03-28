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

        /* 
            Database creates a new record in ComVariation table.
            ComVariation model is the object which contain data to be added. 
        */
        public void AddVariation(ComVariation model)
        {
            model.comvId = Guid.NewGuid();
            _context.Add(model);
            _context.SaveChanges();
        }

        /* 
            Delete a variation using primary key of the table. 
            This function is not yet implemented.  
        */

        public void DeleteVariation(Guid? id)
        {
            throw new NotImplementedException();
        }

        public void EditVariation(ComVariation model)
        {
            throw new NotImplementedException();
        }

        public ComVariation GetVariationById(Guid? id)
        {
            throw new NotImplementedException();
        }

        public List<ComVariation> GetVariations()
        {
            return _context.comVariations.ToList();
        }

        public List<ComVariation> GetVariationsByComId(Guid? comId)
        {
            return _context.comVariations.Where((v) => v.comId == comId).ToList();
        }
    }
}
