using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ad_course_ecom_daham.Models.Product
{
    public class ComVariationOption
    {
        [Key]
        public Guid comvopId { get; set; }
        public string comvopName { get; set; }
        [ForeignKey("comVariation")]
        public Guid comvId { get; set; }
        public ComVariation comVariation { get; set; }
        public decimal price { get; set; }
        public int quantity { get; set; }
    }
}
