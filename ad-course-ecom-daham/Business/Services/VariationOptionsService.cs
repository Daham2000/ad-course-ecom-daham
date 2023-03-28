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

        /*
            Add a new variation to the database. 
            ComVariationOption is the model used to add variation type. 
            Defined primary key using Guid object in c#.
        */
        public void AddVariation(ComVariationOption model)
        {
            model.comvopId = Guid.NewGuid();
            _context.Add(model);
            _context.SaveChanges();
        }

        /* 
            Delete variation filtered using model primary key id. 
        */
        public void DeleteVariation(Guid? id)
        {
            throw new NotImplementedException();
        }

        /* 
            Edit Variation row in the database by using ComVariationOption model object. 
            model contain the data to be updated. 
        */
        public void EditVariation(ComVariationOption model)
        {
            throw new NotImplementedException();
        }

        public ComVariationOption GetVariationById(Guid? id)
        {
            throw new NotImplementedException();
        }

        public List<ComVariationOption> GetVariations()
        {
            throw new NotImplementedException();
        }

        public List<ComVariationOption> GetVariationsByComId(Guid? comvId)
        {
            return _context.comVariationOptions.Where((v) => v.comvId == comvId).ToList();
        }
    }
}
