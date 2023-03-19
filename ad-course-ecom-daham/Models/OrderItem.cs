using ad_course_ecom_daham.Models.Product;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ad_course_ecom_daham.Models
{
    public class OrderItem
    {
        [Key]
        public Guid orId { get; set; }
        [ForeignKey("order")]
        public Guid oId { get; set; }
        public Order order { get; set; }
        [ForeignKey("computer")]
        public Guid comId { get; set; }
        public Computer computer { get; set; }
        public int qty { get; set; }

    }
}
