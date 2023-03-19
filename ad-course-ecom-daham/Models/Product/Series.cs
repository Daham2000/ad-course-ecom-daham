using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ad_course_ecom_daham.Models.Product
{
    public class Series
    {
        [Key]
        public Guid seriesId { get; set; }
        [ForeignKey("category")]
        public Guid cateId { get; set; }
        public Category category { get; set; }
        [NotMapped]
        public string categoryName { get; set; }
        public string seriesName { get; set; }
    }
}
