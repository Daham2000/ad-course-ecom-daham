using ad_course_ecom_daham.Business.Interfaces;
using ad_course_ecom_daham.Data;
using ad_course_ecom_daham.Models.Product;

namespace ad_course_ecom_daham.Business.Services
{
    public class SeriesServices : ISeriesService
    {
        ApplicationDbContext _context;

        public SeriesServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public void AddSeries(Series model)
        {
            model.seriesId = Guid.NewGuid();
            _context.Add(model);
            _context.SaveChanges();
        }

        public void DeleteSeries(Guid? id)
        {
            throw new NotImplementedException();
        }

        public void EditSeries(Series model)
        {
            throw new NotImplementedException();
        }

        public List<Series> GetSeries()
        {
            List<Series> series = _context.series.ToList();
            return series;
        }

        public Series GetSeriesById(Guid? id)
        {
            throw new NotImplementedException();
        }
    }
}
