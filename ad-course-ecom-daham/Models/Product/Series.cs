using System.ComponentModel.DataAnnotations;

namespace ad_course_ecom_daham.Models.Product
{
    public class Series
    {
        [Key]
        public Guid seriesId { get; set; }
        public int seriesName { get; set; }
    }
}
