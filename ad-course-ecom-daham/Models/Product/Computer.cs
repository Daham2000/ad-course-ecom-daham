using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ad_course_ecom_daham.Models.Product
{
    public class Computer
    {
        [Key]
        public int comId { get; set; }
        [ForeignKey("category")]
        public int cateId { get; set; }
        public Category category { get; set; }
        [ForeignKey("series")]
        public int seriesId { get; set; }
        public Series series { get; set; } 
        public string cName { get; set; }
        public decimal normalPrice { get; set; }
    }
}
