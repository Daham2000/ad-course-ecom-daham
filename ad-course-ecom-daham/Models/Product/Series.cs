using System.ComponentModel.DataAnnotations;

namespace ad_course_ecom_daham.Models.Product
{
    public class Series
    {
        [Key]
        public int seriesId { get; set; }
        public int seriesName { get; set; }
    }
}
