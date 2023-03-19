using ad_course_ecom_daham.Models.CustomerModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ad_course_ecom_daham.Models
{
    public class Order
    {
        [Key]
        public int oId { get; set; }
        [ForeignKey("customer")]
        public int cId { get; set; }
        public Customer customer { get; set; }
        public decimal totalPrice { get; set; }
        public string status { get; set; }
        public int totalQty { get; set; }
    }
}
