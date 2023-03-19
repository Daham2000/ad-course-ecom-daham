using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ad_course_ecom_daham.Models.Product
{
    public class ComVariation
    {
        [Key]
        public int comvId { get; set; }
        public string comvName { get; set; }
        [ForeignKey("computer")]
        public int comId { get; set; }
        public Computer computer { get; set; }
    }
}
