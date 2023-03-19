using ad_course_ecom_daham.Models.Product;

namespace ad_course_ecom_daham.Business.Interfaces
{
    public interface ISeriesService
    {
        void AddSeries(Series model);
        List<Series> GetSeries();
        Series GetSeriesById(Guid? id);
        void EditSeries(Series model);
        void DeleteSeries(Guid? id);
    }
}
