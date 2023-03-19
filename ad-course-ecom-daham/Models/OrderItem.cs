using ad_course_ecom_daham.Models.Product;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ad_course_ecom_daham.Models
{
    public class OrderItem
    {
        [Key]
        public int orId { get; set; }
        public int oId { get; set; }
        [ForeignKey("computer")]
        public int comId { get; set; }
        public Computer computer { get; set; }
        public int qty { get; set; }

    }
}
