using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ad_course_ecom_daham.Models.Product
{
    public class Computer
    {
        [Key]
        public Guid comId { get; set; }
        [ForeignKey("category")]
        public Guid cateId { get; set; }
        public Category category { get; set; }
        [ForeignKey("series")]
        public Guid seriesId { get; set; }
        public Series series { get; set; } 
        public string cName { get; set; }
        public string cImage { get; set; }
        public decimal normalPrice { get; set; }
        public int qty { get; set; }
        [NotMapped]
        public string cateName { get; set; }
        [NotMapped]
        public string seriesName { get; set; }
    }
}
